// Import dependencies
var createError = require('http-errors');
var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');
var mysql = require('mysql');
var xmlparser = require('express-xml-bodyparser');

// Define routes dependency
var routes = require('./routes/world');

// Start express
var app = express();

// Configs
app.use(logger('dev'));
app.use(xmlparser());
app.use(express.json());
app.use(express.urlencoded({ extended: true }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));
app.set('view engine', 'jade');


// Define base route
app.use('/api/v1', routes);

// Catch 404 and forward to error handler
app.use(function(req, res, next) {
  next(createError(404));
});

// Error handler
app.use(function(err, req, res, next) {
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};
  res.status(err.status || 500);
  res.render('error');
});

//Server listening
app.listen(3001,() =>{
  console.log('Server started on port 3001...');
});
