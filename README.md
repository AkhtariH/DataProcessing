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
3. Upload sql file (SQL/world.js) to your database
4. Change database credentials in API (REST)/database/dbConnect.js
5. Navigate to API (REST) folder and execute command: ``` npm install ```
6. ``` node index ```

### Python Flask
1. Navigate to Consumer (Python)
2. ``` pip install flask ```
3. ``` flask run ```
4. Go to browser and type in flask URL (usually: http://127.0.0.1:5000)
