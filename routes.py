from flask import render_template, flash, redirect, url_for
from flask_login import current_user, login_user, logout_user, login_required
from app import app, db
from models import Equipment, User
from forms import LoginForm, RegistrationForm, EquipmentForm

@app.route('/')
# ...

@app.route('/')
def home():
    equipment = Equipment.query.all()
    return render_template('home.html', equipment=equipment)

@app.route('/login', methods=['GET', 'POST'])
def login():
    if current_user.is_authenticated:
        return redirect(url_for('home'))

    form = LoginForm()

    # Check form validation and login user
    # ...
    
    return render_template('login.html', form=form)

@app.route('/register', methods=['GET', 'POST'])
def register():
    if current_user.is_authenticated:
        return redirect(url_for('home'))

    form = RegistrationForm()

    # Check form validation and register user
    # ...
    
    return render_template('register.html', form=form)

@app.route('/add', methods=['GET', 'POST'])
@login_required
def add_equipment():
    form = EquipmentForm()

    # Check form validation and add new equipment
    # ...

    return render_template('add.html', form=form)

@app.route('/update/<int:id>', methods=['GET', 'POST'])
@login_required
def update_equipment(id):
    equipment = Equipment.query.get_or_404(id)
    form = EquipmentForm()

    # Check form validation and update equipment
    # ...

    return render_template('update.html', form=form, equipment=equipment)

@app.route('/delete/<int:id>', methods=['POST'])
@login_required
def delete_equipment(id):
    equipment = Equipment.query.get_or_404(id)
    db.session.delete(equipment)
    db.session.commit()
    flash('Equipment deleted successfully.')
    return redirect(url_for('home'))
