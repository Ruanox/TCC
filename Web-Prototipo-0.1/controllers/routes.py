# Importando o flask para a aplicação
from flask import render_template, request, redirect, url_for
# Importando os modelos
from models.database import Aluno, Professor, Escola, db


# Criado a função principal para inicializar as rotas
def init_app(app):
    
    # Criando a rota principal do site
    @app.route('/')
    # def cria funções no python
    def home():
        return render_template('index.html')

    # Rota para listar e cadastrar escolas
    @app.route('/escolas', methods=['GET', 'POST'])
    def escolas():
        if request.method == 'POST':
            nome = request.form.get('nome')
            endereco = request.form.get('endereco')
            telefone = request.form.get('telefone')
            email = request.form.get('email')
            
            nova_escola = Escola(nome, endereco, telefone, email)
            db.session.add(nova_escola)
            db.session.commit()
            return redirect(url_for('escolas'))
        
        escolas = Escola.query.all()
        return render_template('escolas.html', escolas=escolas)

    # Rota para listar e cadastrar professores
    @app.route('/professores', methods=['GET', 'POST'])
    def professores():
        if request.method == 'POST':
            nome = request.form.get('nome')
            cpf = request.form.get('cpf')
            email = request.form.get('email')
            telefone = request.form.get('telefone')
            especialidade = request.form.get('especialidade')
            escola_id = request.form.get('escola_id')
            
            novo_professor = Professor(nome, cpf, email, telefone, especialidade, escola_id)
            db.session.add(novo_professor)
            db.session.commit()
            return redirect(url_for('professores'))
        
        professores = Professor.query.all()
        escolas = Escola.query.all()
        return render_template('professores.html', professores=professores, escolas=escolas)

    # Rota para listar e cadastrar alunos
    @app.route('/alunos', methods=['GET', 'POST'])
    def alunos():
        if request.method == 'POST':
            nome = request.form.get('nome')
            cpf = request.form.get('cpf')
            email = request.form.get('email')
            telefone = request.form.get('telefone')
            data_nascimento = request.form.get('data_nascimento')
            esporte = request.form.get('esporte')
            escola_id = request.form.get('escola_id')
            professor_id = request.form.get('professor_id')
            
            novo_aluno = Aluno(nome, cpf, email, telefone, data_nascimento, esporte, escola_id, professor_id)
            db.session.add(novo_aluno)
            db.session.commit()
            return redirect(url_for('alunos'))
        
        alunos = Aluno.query.all()
        escolas = Escola.query.all()
        professores = Professor.query.all()
        return render_template('alunos.html', alunos=alunos, escolas=escolas, professores=professores)
    
    # Rota para visualizar detalhes de uma escola
    @app.route('/escola/<int:id>')
    def detalhes_escola(id):
        escola = Escola.query.get(id)
        professores = Professor.query.filter_by(escola_id=id).all()
        alunos = Aluno.query.filter_by(escola_id=id).all()
        return render_template('detalhes_escola.html', escola=escola, professores=professores, alunos=alunos)
    
    # Rota para deletar escola
    @app.route('/deletar_escola/<int:id>')
    def deletar_escola(id):
        escola = Escola.query.get(id)
        db.session.delete(escola)
        db.session.commit()
        return redirect(url_for('escolas'))
    
    # Rota para deletar professor
    @app.route('/deletar_professor/<int:id>')
    def deletar_professor(id):
        professor = Professor.query.get(id)
        db.session.delete(professor)
        db.session.commit()
        return redirect(url_for('professores'))
    
    # Rota para deletar aluno
    @app.route('/deletar_aluno/<int:id>')
    def deletar_aluno(id):
        aluno = Aluno.query.get(id)
        db.session.delete(aluno)
        db.session.commit()
        return redirect(url_for('alunos'))