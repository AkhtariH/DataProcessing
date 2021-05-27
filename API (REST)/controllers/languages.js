// Get connection
var connection = require('../database/dbConnect.js');

// Gets all languages
const languages = (req, res, next) => {
	// Execute SQL Query
	let sql = "SELECT * FROM countrylanguage;";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;

		// Create base JSON structure
		var result = null;
		var languagesJson = {
			Languages: []
		};

		// Add each Query result to JSON var
		for (var i = 0; i < results.length; i++) {
			var languageJson = {
				Language : results[i]
			};
			languagesJson.Languages.push(languageJson);
		}


		// If request headers contain content type as XML
		if (req.headers['content-type'] == "application/xml"){
			// Build XML Structre
			var xmlString = "<?xml version=\"1.0\"?>\n";
			xmlString += "<Languages xmlns:xs=\"schema.xsd\">\n";
			for (var i = 0; i < results.length; i++) {
				xmlString += "<Language>\n";
				Object.keys(results[i]).forEach(function(key) {
				    var value = results[i][key];
				    xmlString += "<" + key + ">" + value + "</" + key + ">\n";
				});
				xmlString += "</Language>\n";
			}

			xmlString += "</Languages>\n";

			res.charset = 'utf-8';

			// Put XMLString into the results variable 
			result = xmlString;		
		} else { // If Header is nothing or JSON
			// Put JSON into the results variable
			result = languagesJson;
		}

		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": result}));
	});
};


// Gets language with specified Code
const language = (req, res, next) => {
	// Get request Parameter Code
	let data = [req.params.code];

	// Execute SQL Query
	let sql = "SELECT * FROM countrylanguage WHERE CountryCode = ?;";
	let query = connection.query(sql, data, (err, results) => {
		if(err) throw err;

		// Create base JSON structure
		var result = null;
		var languagesJson = {
			Languages: []
		};

		// Add each Query result to JSON var
		for (var i = 0; i < results.length; i++) {
			var languageJson = {
				Language : results[i]
			};
			languagesJson.Languages.push(languageJson);
		}


		// If request headers contain content type as XML
		if (req.headers['content-type'] == "application/xml"){
			// Build XML Structure
			var xmlString = "<?xml version=\"1.0\"?>\n";
			xmlString += "<Languages xmlns:xs=\"schema.xsd\">\n";
			for (var i = 0; i < results.length; i++) {
				xmlString += "<Language>\n";
				Object.keys(results[i]).forEach(function(key) {
				    var value = results[i][key];
				    xmlString += "<" + key + ">" + value + "</" + key + ">\n";
				});
				xmlString += "</Language>\n";
			}

			xmlString += "</Languages>\n";

			res.charset = 'utf-8';

			// Put XMLString into the results variable 
			result = xmlString;
		} else { // If Header is nothing or JSON
			result = languagesJson; // Put JSON into the results variable
		}

		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": result}));
	});
};

// Creates language entry in DB
const create = (req, res, next) => {
	let languages = null;
	let sql = "INSERT INTO countrylanguage SET ?";
	// If request headers contain content type as XML
	if (req.headers['content-type'] == "application/xml"){
		// Get body of request
		languages = req.body.languages.language;

		// For each Language entry, execute INSERT Query
		let data = [];
		for (var i = 0; i < languages.length; i++) {
			data.push(languages[i]);
			let query = connection.query(sql, data, (err, results) => {
				if(err) console.log(err);
			});
		}

	} else { // If request headers are nothing or JSON
		// Get body of request
		languages = req.body.Languages;
		// For each Language entry, execute INSERT Query
		for (var i = 0; i < languages.length; i++) {
			let data = [];
			Object.keys(languages[i]).forEach(function(key) {
				let value = languages[i][key];
				data.push(value);
			});
			
			let query = connection.query(sql, data)
		}
	}

	// Send response with Status, Error and Result
	res.send(JSON.stringify({"status": 200, "error": null, "response": "Success"}));
};

// Update language entry in DB
const update = (req, res, next) => {
	let languages = null;
	let data = [];

	// If request headers contain content type as XML
	if (req.headers['content-type'] == "application/xml"){
		// Get body of request
		languages = req.body.languages.language;
		// For each Language entry, execute UPDATE Query
		for (var i = 0; i < languages.length; i++) {
			data.push(languages[i]);
		}
	} else {
		// Get body of request
		languages = req.body.Languages;
		// For each Language entry, execute UPDATE Query
		for (var i = 0; i < languages.length; i++) {
			Object.keys(languages[i]).forEach(function(key) {
				let value = languages[i][key];
				data.push(value);
			});
		}
	}

	let sql = "UPDATE countrylanguage SET ? WHERE Code = '" + req.params.code + "'";
	let query = connection.query(sql, data, (err, results) => {
		if(err) throw err;
		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

// Delete language with specified Code
const del = (req, res, next) => {
	let sql = "DELETE FROM countrylanguage WHERE Code = '" + req.params.code + "'";
	let query = connection.query(sql, (err, results) => {
		if(err) throw err;
		// Send response with Status, Error and Result
		res.send(JSON.stringify({"status": 200, "error": null, "response": results}));
	});
};

// Export all modules and operations
module.exports = {
	languages,
	language,
	create,
	update,
	del
};