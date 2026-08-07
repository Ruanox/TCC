from flask import render_template


def init_app(app):
    @app.route('/')
    def home():
        return render_template('index.html')

    @app.route('/funcionalidades')
    def funcionalidades():
        return render_template('index.html')

    @app.route('/download')
    def download():
        return render_template('index.html')

    @app.route('/campeonatos')
    def campeonatos():
        return render_template('campeonatos.html')

    @app.route('/cadastro')
    def cadastro():
        return render_template('cadastro.html')
