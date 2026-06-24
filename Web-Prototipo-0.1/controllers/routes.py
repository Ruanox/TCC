# Importando o flask para a aplicação
from flask import render_template, request, redirect, url_for
# Importando os modelos
from models.database import Aluno, Professor, Escola, db

# Criado a função principal para inicializar as rotas
def init_app(app):
    
    # Criando a rota principal do site
    @app.route('/')
    def home():
        return render_template('index.html')

    # Rota para listar e cadastrar escolas
    @app.route('/escolas', methods=['GET', 'POST'])
    def escolas():
        if request.method == 'POST':
            cnpj = request.form.get('cnpj')
            usuario = request.form.get('usuario')
            email = request.form.get('email')
            telefone = request.form.get('telefone')
            rua = request.form.get('rua')
            bairro = request.form.get('bairro')
            cidade = request.form.get('cidade')
            estado = request.form.get('estado')
            
            nova_escola = Escola(cnpj, email, usuario, telefone, rua, bairro, cidade, estado)
            db.session.add(nova_escola)
            db.session.commit()
            return redirect(url_for('escolas'))
        
        escolas = Escola.query.all()
        return render_template('escolas.html', escolas=escolas)

    # Rota para listar e cadastrar professores
    @app.route('/professores', methods=['GET', 'POST'])
    def professores():
        if request.method == 'POST':
            usuario = request.form.get('usuario')
            cpf = request.form.get('cpf')
            email = request.form.get('email')
            senha = request.form.get('senha')
            telefone = request.form.get('telefone')
            rua = request.form.get('rua')
            bairro = request.form.get('bairro')
            cidade = request.form.get('cidade')
            estado = request.form.get('estado')
            num_casa = request.form.get('num_casa') or None
            
            novo_professor = Professor(usuario, cpf, email, senha, telefone, rua, bairro, cidade, estado, num_casa)
            db.session.add(novo_professor)
            db.session.commit()
            return redirect(url_for('professores'))
        
        professores = Professor.query.all()
        return render_template('professores.html', professores=professores)

    # Rota para listar e cadastrar alunos
    @app.route('/alunos', methods=['GET', 'POST'])
    def alunos():
        if request.method == 'POST':
            usuario = request.form.get('usuario')
            cpf = request.form.get('cpf')
            senha = request.form.get('senha')
            nome_responsavel = request.form.get('nome_responsavel')
            telefone_responsavel = request.form.get('telefone_responsavel')
            cpf_responsavel = request.form.get('cpf_responsavel')
            rua = request.form.get('rua')
            bairro = request.form.get('bairro')
            cidade = request.form.get('cidade')
            estado = request.form.get('estado')
            num_casa = request.form.get('num_casa') or None
            
            novo_aluno = Aluno(usuario, cpf, senha, nome_responsavel, telefone_responsavel, cpf_responsavel, rua, bairro, cidade, estado, num_casa)
            db.session.add(novo_aluno)
            db.session.commit()
            return redirect(url_for('alunos'))
        
        alunos = Aluno.query.all()
        return render_template('alunos.html', alunos=alunos)
    
    # Rota para visualizar detalhes de uma escola
    @app.route('/escola/<cnpj>')
    def detalhes_escola(cnpj):
        escola = Escola.query.get(cnpj)
        return render_template('detalhes_escola.html', escola=escola)
    
    # Rota para deletar escola
    @app.route('/deletar_escola/<cnpj>')
    def deletar_escola(cnpj):
        escola = Escola.query.get(cnpj)
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
