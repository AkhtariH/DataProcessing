using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace WorldREST
{
    

    public partial class Form1 : Form
    {
        private string currentCountryCode;
        private string responseType = "json";
        private static bool schemaValid = true;

        public Form1()
        {
            InitializeComponent();
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            // Bind combobox to dictionary
            comboBox3.Items.Add("JSON");
            comboBox3.Items.Add("XML");
            comboBox3.SelectedIndex = 0;
        }

        // Gets data from API, validates it and deserialize it to classes
        public static CountryInfo GetCountryInfo(string type, string country)
        {
            
            CountryInfo sa = null;
            // API call              
                var webRequest2 = WebRequest.Create("http://localhost:3001/api/v1/countries/" + country) as HttpWebRequest;
                webRequest2.ContentType = "application/xml";
                webRequest2.UserAgent = "Nothing";

                XmlSerializer serializer = new XmlSerializer(typeof(countries));
                using (var s = webRequest2.GetResponse().GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                        var countryAsJson = sr.ReadToEnd();


                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(countryAsJson);

                        // Path to XML schema
                        xml.Schemas.Add(null, @"schema.xsd");

                        // Try catches validation
                        try
                        {
                            xml.Validate(null);

                        }
                        catch (XmlSchemaValidationException)
                        {
                            schemaValid = false;
                            //Console.WriteLine(schemaValid);
                        }

                        using (TextReader reader = new StringReader(countryAsJson))
                        {
                            countries result = (countries)serializer.Deserialize(reader);
                            sa = result.Country[0];
                        }

                        //var countries = JsonConvert.DeserializeObject<CountryInfo>(countryAsJson);


                    }
                }
            

            return sa;
        }

        public static CountryInfoJson GetCountryInfoJson(string type, string country)
        {

            CountryInfoJson sa = null;
            // API call
            var webRequest = WebRequest.Create("http://localhost:3001/api/v1/countries/" + country) as HttpWebRequest;

            if (type == "json" || type == "JSON")
            {
                webRequest.ContentType = "application/json";
                webRequest.UserAgent = "Nothing";

                using (var s = webRequest.GetResponse().GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                        var countryAsJson = sr.ReadToEnd();

                        var countries = JsonConvert.DeserializeObject<CountryInfoJson>(countryAsJson);

                        var dataObject = new
                        {
                            // Path to draft-07 schema
                            data = File.ReadAllText(@"schema.json")
                        };


                        string dataObjectString = JsonConvert.SerializeObject(dataObject);

                        JsonSchema schema1 = JsonSchema.Parse(dataObjectString);

                        var schema = JSchema.Parse(schema1.ToString());

                        JObject countryJ = JObject.Parse(countryAsJson);

                        IList<string> messages;
                        // Checks if JSON is valid
                        bool valid = countryJ.IsValid(schema, out messages);

                        Console.WriteLine(messages.Count);

                        schemaValid = valid;
                        sa = countries;
                    }
                }
            }

            return sa;
        }

        // Gets all country codes for Key Value Pair in comboBox1
        public static String[] GetCountryCodes()
        {

            var webRequest = WebRequest.Create("http://localhost:3001/api/v1/countries") as HttpWebRequest;

            webRequest.ContentType = "text/comma-separated-values";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var country = sr.ReadToEnd();

                    String[] countryNames = country.Split(new char[] { ',' });

                    var charsToRemove = new string[] { "\"", "[", "]" };
                    foreach (var c in charsToRemove)
                    {
                        countryNames[0] = countryNames[0].Replace(c, string.Empty);
                        countryNames[1] = countryNames[1].Replace(c, string.Empty);
                    }

                    String[] code = countryNames[0].Split(new char[] { ';' });

                    return code;
                }
            }

        }

        // Gets all country names for comboBox1
        public static String[] GetCountryNames()
        {

            var webRequest = WebRequest.Create("http://localhost:3001/api/v1/countries") as HttpWebRequest;

            webRequest.ContentType = "text/comma-separated-values";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var country = sr.ReadToEnd();

                    String[] countryNames = country.Split(new char[] { ',' });

                    var charsToRemove = new string[] { "\"", "[", "]" };
                    foreach (var c in charsToRemove)
                    {
                        countryNames[0] = countryNames[0].Replace(c, string.Empty);
                        countryNames[1] = countryNames[1].Replace(c, string.Empty);
                    }

                    String[] names = countryNames[1].Split(new char[] { ';' });

                    return names;
                }
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // initiates Key Valuefor comboBox 1 and 2
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            String[] countries = GetCountryNames();
            String[] codes = GetCountryCodes();

            for (int i = 0; i <= countries.Length - 1; i++)
            {
                comboSource.Add(codes[i], countries[i]);
            }

            comboBox1.DataSource = new BindingSource(comboSource, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            comboBox2.DataSource = new BindingSource(comboSource, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";

            if (schemaValid == true)
            {
                label13.ForeColor = Color.Green;
            } else
            {
                label13.ForeColor = Color.Red;
            }
            label13.Text = schemaValid.ToString();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void GeneralTab_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (schemaValid == true)
            {
                label13.ForeColor = Color.Green;
                label13.Text = "True";
            }
            else if (schemaValid == false)
            {
                label13.ForeColor = Color.Red;
                label13.Text = "False";
            }
            
            currentCountryCode = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;

            //var countryInfo = null;
            if (responseType == "json" || responseType == "JSON")
            {
                var countryInfo = GetCountryInfoJson(responseType, currentCountryCode);

                // Refresh infos
                nameLabel.Text = countryInfo.Name;
                continentLabel.Text = countryInfo.Continent;
                regionLabel.Text = countryInfo.Region;
                areaLabel.Text = countryInfo.SurfaceArea.ToString() + " km²";
                populationLabel.Text = countryInfo.Population.ToString();
                lifeLabel.Text = countryInfo.LifeExpectancy.ToString() + " Years";
                gnpLabel.Text = countryInfo.GNP.ToString();
                headofstateLabel.Text = countryInfo.HeadOfState;
                capitalLabel.Text = countryInfo.Capital.ToString();


                //Generate Pie chart for languages

                Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

                SeriesCollection piechartData = new SeriesCollection { };

                System.Windows.Media.Brush[] brushes = new System.Windows.Media.Brush[] {
              System.Windows.Media.Brushes.Violet,
              System.Windows.Media.Brushes.Magenta,
              System.Windows.Media.Brushes.Red,
              System.Windows.Media.Brushes.Lime,
              System.Windows.Media.Brushes.Orange,
              System.Windows.Media.Brushes.DarkRed,
              System.Windows.Media.Brushes.Gray
            };

                Random rnd = new Random();
                List<int> numberList = new List<int>();
                // Gets all languages
                foreach (var languageData in countryInfo.Languages)
                {
                    var rand = rnd.Next(brushes.Length);
                    while (numberList.Contains(rand))
                    {
                        rand = rnd.Next(brushes.Length);
                    }

                    numberList.Add(rand);

                    System.Windows.Media.Brush brush = brushes[rand];

                    piechartData.Add(
                        new PieSeries
                        {
                            Title = languageData.Language,
                            Values = new ChartValues<double> { Double.Parse(languageData.Percentage.ToString()) },
                            DataLabels = true,
                            LabelPoint = labelPoint,
                            Fill = brush
                        }
                    );

                }
                pieChart1.Series = piechartData;

                pieChart1.LegendLocation = LegendLocation.Right;


                Dictionary<string, string> comboSourceCity = new Dictionary<string, string>();

                foreach (var citiesData in countryInfo.Cities)
                {
                    //Console.WriteLine("TEst: " + citiesData.Name);
                    comboSourceCity.Add(citiesData.Name, citiesData.Population);
                }

                listBox1.DataSource = new BindingSource(comboSourceCity, null);
                listBox1.DisplayMember = "Key";
                listBox1.ValueMember = "Value";
            } else if (responseType == "xml" || responseType == "XML")
            {
                var countryInfo = GetCountryInfo(responseType, currentCountryCode);

                // Refresh infos
                nameLabel.Text = countryInfo.Name;
                continentLabel.Text = countryInfo.Continent;
                regionLabel.Text = countryInfo.Region;
                areaLabel.Text = countryInfo.SurfaceArea.ToString() + " km²";
                populationLabel.Text = countryInfo.Population.ToString();
                lifeLabel.Text = countryInfo.LifeExpectancy.ToString() + " Years";
                gnpLabel.Text = countryInfo.GNP.ToString();
                headofstateLabel.Text = countryInfo.HeadOfState;
                capitalLabel.Text = countryInfo.Capital.ToString();


                //Generate Pie chart for languages

                Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

                SeriesCollection piechartData = new SeriesCollection { };

                System.Windows.Media.Brush[] brushes = new System.Windows.Media.Brush[] {
              System.Windows.Media.Brushes.Violet,
              System.Windows.Media.Brushes.Magenta,
              System.Windows.Media.Brushes.Red,
              System.Windows.Media.Brushes.Lime,
              System.Windows.Media.Brushes.Orange,
              System.Windows.Media.Brushes.DarkRed,
              System.Windows.Media.Brushes.Gray
            };

                Random rnd = new Random();
                List<int> numberList = new List<int>();
                // Gets all languages
                foreach (var languageData in countryInfo.Languages)
                {
                    var rand = rnd.Next(brushes.Length);
                    while (numberList.Contains(rand))
                    {
                        rand = rnd.Next(brushes.Length);
                    }

                    numberList.Add(rand);

                    System.Windows.Media.Brush brush = brushes[rand];

                    piechartData.Add(
                        new PieSeries
                        {
                            Title = languageData.Language,
                            Values = new ChartValues<double> { Double.Parse(languageData.Percentage.ToString()) },
                            DataLabels = true,
                            LabelPoint = labelPoint,
                            Fill = brush
                        }
                    );

                }
                pieChart1.Series = piechartData;

                pieChart1.LegendLocation = LegendLocation.Right;


                Dictionary<string, string> comboSourceCity = new Dictionary<string, string>();

                foreach (var citiesData in countryInfo.Cities.City)
                {
                    //Console.WriteLine("TEst: " + citiesData.Name);
                    comboSourceCity.Add(citiesData.Name, citiesData.Population);
                }

                listBox1.DataSource = new BindingSource(comboSourceCity, null);
                listBox1.DisplayMember = "Key";
                listBox1.ValueMember = "Value";
            }




            

        }

        // Mapped Classes
        public class CountryCities
        {
            [XmlElement("City")]
            public List<CountryCity> City { get; set; }
        }

        public class CountryCity
        {
            [XmlElement("Name")]
            public string Name { get; set; }
            [XmlElement("CountryCode")]
            public string CountryCode { get; set; }
            [XmlElement("Population")]
            public string Population { get; set; }
        }

        public class CountryLanguages
        {
            [XmlElement("CountryCode")]
            public string CountryCode { get; set; }
            [XmlElement("Language")]
            public string Language { get; set; }
            [XmlElement("IsOfficial")]
            public string IsOfficial { get; set; }
            [XmlElement("Percentage")]
            public float Percentage { get; set; }
        }

        
        public class CountryInfo
        {
            [XmlElement("Code")]
            public string Code { get; set; }
            [XmlElement("Name")]
            public string Name { get; set; }
            [XmlElement("Continent")]
            public string Continent { get; set; }
            [XmlElement("Region")]
            public string Region { get; set; }
            [XmlElement("SurfaceArea")]
            public float SurfaceArea { get; set; }
            [XmlElement("Population")]
            public int Population { get; set; }
            [XmlElement("LifeExpectancy")]
            public float LifeExpectancy { get; set; }
            [XmlElement("GNP")]
            public float GNP { get; set; }
            [XmlElement("HeadOfState")]
            public string HeadOfState { get; set; }
            [XmlElement("Capital")]
            public int Capital { get; set; }
            [XmlElement("Code2")]
            public string Code2 { get; set; }
            [XmlElement("Cities")]
            public CountryCities Cities { get; set; }
            [XmlElement("Languages")]
            public List<CountryLanguages> Languages { get; set; }
        }

        [XmlRoot("Countries")]
        public class countries
        {
            [XmlElement("Country")]
            public List<CountryInfo> Country { get; set; }
        }

        // Mapped Classes

        public class CountryCitiesJson
        {
            public string Name { get; set; }
            public string CountryCode { get; set; }
            public string Population { get; set; }
        }

        public class CountryLanguagesJson
        {
            public string CountryCode { get; set; }
            public string Language { get; set; }
            public string IsOfficial { get; set; }
            public float Percentage { get; set; }
        }


        public class CountryInfoJson
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string Continent { get; set; }
            public string Region { get; set; }
            public float SurfaceArea { get; set; }
            public int Population { get; set; }
            public float LifeExpectancy { get; set; }
            public float GNP { get; set; }
            public string HeadOfState { get; set; }
            public int Capital { get; set; }
            public string Code2 { get; set; }
            public List<CountryCitiesJson> Cities { get; set; }
            public List<CountryLanguagesJson> Languages { get; set; }
        }

        public class countriesJson
        {
            public List<CountryInfo> Country { get; set; }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string population = listBox1.GetItemText(listBox1.SelectedValue);

            cityPopulation.Text = population;
        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            var compareCountryCode = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Key;

            var currentCountry = GetCountryInfo("json", currentCountryCode);
            var countryInfoCompare = GetCountryInfo("json", compareCountryCode);

            chart1.Series[0].Points.AddY(currentCountry.Population);
            chart1.Series[1].Points.AddY(countryInfoCompare.Population);

            chart1.Series[0].LegendText = currentCountry.Name;
            chart1.Series[1].LegendText = countryInfoCompare.Name;

            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            responseType = comboBox3.Text;
        }

        private void Label11_Click_1(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }
    }
}
