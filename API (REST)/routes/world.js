// Import dependencies
const express = require('express');
const router  = express.Router(); 
const countriesController = require('../controllers/countries'); 
const languagesController = require('../controllers/languages'); 
const citiesController = require('../controllers/cities'); 
var xmlparser = require('express-xml-bodyparser');

// Countries Routes (CRUD)
router.get('/countries/codes', countriesController.codes);
router.get('/countries/exist/:code', countriesController.exist);
router.get('/countries', countriesController.countries);
router.get('/countries/:code', countriesController.country);
router.post('/countries', xmlparser(), countriesController.create);
router.put('/countries/:code', xmlparser(), countriesController.update);
router.delete('/countries/:code', xmlparser(), countriesController.del);

// Language Routes (CRUD)
router.get('/languages', languagesController.languages);
router.get('/languages/:code', languagesController.language);
router.post('/languages', xmlparser(), languagesController.create);
router.put('/languages/:code', xmlparser(), languagesController.update);
router.delete('/languages/:code', xmlparser(), languagesController.del);

// Cities Routes (CRUD)
router.get('/cities/districts/:code', citiesController.districts);
router.get('/cities', citiesController.cities);
router.get('/cities/:code', citiesController.city);
router.post('/cities', xmlparser(), citiesController.create);
router.put('/cities/:code', xmlparser(), citiesController.update);
router.delete('/cities/:code', xmlparser(), citiesController.del);

module.exports = router; // export to use in index.js