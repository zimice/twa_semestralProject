from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from flask_login import LoginManager

from config import Config

# Instantiate the Flask application, SQLAlchemy, and LoginManager
app = Flask(__name__)
app.config.from_object(Config)
db = SQLAlchemy(app)
login = LoginManager(app)
login.login_view = 'login'  # The name of the view to redirect to when the user needs to log in.

# Import the routes module
import routes
