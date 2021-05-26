from flask import Flask, render_template
app = Flask(__name__, template_folder='./views')

from app import routes

app.config['TEMPLATES_AUTO_RELOAD'] = True

if __name__ == '__main__':
   app.run()