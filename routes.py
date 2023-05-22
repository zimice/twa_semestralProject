@app.route('/')
def home():
    equipment = Equipment.query.all()
    return render_template('home.html', equipment=equipment)

@app.route('/login', methods=['GET', 'POST'])
def login():
    form = LoginForm()
    # Validate form and log in user
    # Remember to check password
    return render_template('login.html', form=form)

@app.route('/register', methods=['GET', 'POST'])
def register():
    form = RegistrationForm()
    # Validate form and register new user
    # Remember to hash password
    return render_template('register.html', form=form)

@app.route('/add', methods=['GET', 'POST'])
def add_equipment():
    form = EquipmentForm()
    # Validate form and add new equipment
    return render_template('add.html', form=form)

@app.route('/update/<int:id>', methods=['GET', 'POST'])
def update_equipment(id):
    equipment = Equipment.query.get_or_404(id)
    form = EquipmentForm()
    # Validate form and update equipment
    return render_template('update.html', form=form)

@app.route('/delete/<int:id>', methods=['POST'])
def delete_equipment(id):
    equipment = Equipment.query.get_or_404(id)
    # Delete equipment
    return redirect(url_for('home'))

@login_manager.user_loader
def load_user(user_id):
    return User.query.get(int(user_id))