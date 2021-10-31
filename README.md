# Data Processing

## Description

The objective of this assignment is to develop an API with a language of choice and a program that consume that API. The Application should be able to process JSON as well as XML data.
I used Node.JS for the API and Python Flask to consume it.

## Documentation

[Click here](https://github.com/AkhtariH/DataProcessing/raw/master/Documentation_Hemran_Akhtari.docx).

## Requirements
- [Node.JS](https://nodejs.org/en/download/)
- MySQL (I used XAMPP)
- [Python](https://www.python.org/downloads/)

## Installation

### Node.JS Server
1. ``` git clone https://github.com/AkhtariH/DataProcessing.git ```
2. ``` cd DataProcessing ```
3. Create database named world and upload sql file (SQL/world.sql) to your database
4. Change database credentials in API/database/dbConnect.js if needed
5. ``` cd API ```
6. ``` npm install ```
7. ``` node index ```

### Python Flask
1. Open new command line
2. Navigate to Consumer folder
3. Install virtualenv: ``` pip3 install -U pip virtualenv ```
4. ``` python -m virtualenv . ```
5. Activate Env: ``` .\scripts\activate ```
6. Install dependencies: ``` pip3 install -r requirements.txt ```
7. Run app: ``` flask run ```
8. Go to browser and type in flask URL (usually: http://127.0.0.1:5000)
