# Import dependencies
from flask import Flask, render_template
app = Flask(__name__, template_folder='./views') # Set default temp folder
# Import routes
from app import routes
# Make Templates reload on save
app.config['TEMPLATES_AUTO_RELOAD'] = True
# Run app
if __name__ == '__main__':
   app.run()