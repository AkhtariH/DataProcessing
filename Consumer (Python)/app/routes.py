# Import dependencies
from app import app
from flask import render_template, redirect
import requests
import xml.etree.ElementTree as ET
# If url has no Code, redirect to first country in dataset
@app.route('/')
def home():
	# Get Country Codes
	allCountries = requests.get("http://localhost:3001/api/v1/countries/codes").json()
	return redirect('/' + allCountries[0]['Code'])

# If url has no Code, redirect to first country in dataset
@app.route('/xml')
def homeXML():
	# Get Country Codes
	allCountries = requests.get("http://localhost:3001/api/v1/countries/codes").json()
	return redirect('/xml/' + allCountries[0]['Code'])

# Route to XML Page
@app.route('/xml/<string:code>')
def indexXML(code):
	# Check if Code exists
	exists = requests.get("http://localhost:3001/api/v1/countries/exist/" + code).json()
	if exists == False:
		allCountries = requests.get("http://localhost:3001/api/v1/countries/codes").json()
		return redirect('/xml/' + allCountries[0]['Code'])
	# Change Content Type Header to XML and get all necessary data from API
	headers = {'Content-type': 'application/xml'}
	allCountries = requests.get("http://localhost:3001/api/v1/countries/codes").json()
	districts = requests.get("http://localhost:3001/api/v1/cities/districts/" + code).json()['response']
	countriesResponse = requests.get("http://localhost:3001/api/v1/countries/" + code, headers=headers).json()['response']
	citiesResponse = requests.get("http://localhost:3001/api/v1/cities/" + code, headers=headers).json()['response']
	languagesResponse = requests.get("http://localhost:3001/api/v1/languages/" + code, headers=headers).json()['response']
	# Parse XML String to ElemenTree (XML Object)
	citiesRoot = ET.ElementTree(ET.fromstring(citiesResponse)).getroot()
	languagesRoot = ET.ElementTree(ET.fromstring(languagesResponse)).getroot()
	countryRoot = ET.ElementTree(ET.fromstring(countriesResponse)).getroot()
	# Save specified Country in variable
	for elem in countryRoot.findall('Country'):
		country = elem

	# Convert Population number to Thoudsands or Millions
	countryPopulation = country.find('Population').text # Get Population of Country
	populationSize = len(str(countryPopulation))
	population = 0
	if populationSize >= 5 and populationSize <= 6:
		population = int(countryPopulation) // 1000
	elif populationSize >= 7:
		population = round(int(countryPopulation), -6) // 1000000
	else:
		population = int(countryPopulation)

	# Convert Surface Area number to Thousands or Millions
	countrySurfaceArea = country.find('SurfaceArea').text # Get Surface Area of Country
	surfaceAreaLength = len(str(countrySurfaceArea))
	surfaceArea = 0
	if surfaceAreaLength >= 5 and surfaceAreaLength <= 6:
		surfaceArea = int(countrySurfaceArea) // 1000
	elif surfaceAreaLength >= 7:
		surfaceArea = round(int(countrySurfaceArea), -6) // 1000000
	else:
		surfaceArea = int(countrySurfaceArea)

	# Convert GNP number to Thousands or Millions
	countryGNP = country.find('GNP').text
	gnpLenght = len(str(countryGNP))
	gnp = 0
	if gnpLenght >= 5 and gnpLenght <= 6:
		gnp = float(countryGNP) // 1000
	elif gnpLenght >= 7:
		gnp = round(float(countryGNP), -6) // 1000000
	else:
		gnp = float(countryGNP)
	# Return template and pass variables to template
	return render_template('XMLindex.html', country=country, cities=citiesRoot, languages=languagesRoot, allCountries=allCountries, districts=districts, population=population, surfaceArea=surfaceArea, gnp=gnp)

# Route to JSON Page
@app.route('/<string:code>')
def index(code):
	# Check if Code exists
	exists = requests.get("http://localhost:3001/api/v1/countries/exist/" + code).json()
	if exists == False:
		allCountries = requests.get("http://localhost:3001/api/v1/countries/codes").json()
		return redirect('/' + allCountries[0]['Code'])
	# Change Content Type Header to XML and get all necessary data from API
	allCountries = requests.get("http://localhost:3001/api/v1/countries/codes").json()
	districts = requests.get("http://localhost:3001/api/v1/cities/districts/" + code).json()['response']
	countriesResponse = requests.get("http://localhost:3001/api/v1/countries/" + code).json()['response']
	citiesResponse = requests.get("http://localhost:3001/api/v1/cities/" + code).json()['response']
	languagesResponse = requests.get("http://localhost:3001/api/v1/languages/" + code).json()['response']

	# Convert Population number to Thoudsands or Millions
	countryPopulation = countriesResponse["Countries"][0]["Country"]["Population"]
	populationSize = len(str(countryPopulation))
	population = 0
	if populationSize >= 5 and populationSize <= 6:
		population = countryPopulation // 1000
	elif populationSize >= 7:
		population = round(countryPopulation, -6) // 1000000
	else:
		population = countryPopulation

	# Convert Surface Area number to Thousands or Millions
	countrySurfaceArea = countriesResponse["Countries"][0]["Country"]["SurfaceArea"]
	surfaceAreaLength = len(str(countrySurfaceArea))
	surfaceArea = 0
	if surfaceAreaLength >= 5 and surfaceAreaLength <= 6:
		surfaceArea = countrySurfaceArea // 1000
	elif surfaceAreaLength >= 7:
		surfaceArea = round(countrySurfaceArea, -6) // 1000000
	else:
		surfaceArea = countrySurfaceArea

	# Convert GNP number to Thousands or Millions
	countryGNP = countriesResponse["Countries"][0]["Country"]["GNP"]
	gnpLenght = len(str(countryGNP))
	gnp = 0
	if gnpLenght >= 5 and gnpLenght <= 6:
		gnp = countryGNP // 1000
	elif gnpLenght >= 7:
		gnp = round(countryGNP, -6) // 1000000
	else:
		gnp = countryGNP
	# Return template and pass variables to template
	return render_template('index.html', districts=districts, allCountries=allCountries, countries=countriesResponse['Countries'], cities=citiesResponse['Cities'], languages=languagesResponse['Languages'], population=population, surfaceArea=surfaceArea, gnp=gnp)