# Importando o Flask-SQLAlchemy
from flask_sqlalchemy import SQLAlchemy
# Carregando o SqlAlchemy em uma variável chamada db
db = SQLAlchemy()

# Criando uma classe para representar a entidade Escola no banco de dados
class Escola(db.Model):
    # definindo atributos (colunas) da tabela Escola
    # Schema
    id = db.Column(db.Integer, primary_key=True)  # Coluna de ID, chave primária
    nome = db.Column(db.String(150))  # Coluna de nome, string de até 150 caracteres
    endereco = db.Column(db.String(200))  # Coluna de endereço
    telefone = db.Column(db.String(20))  # Coluna de telefone
    email = db.Column(db.String(100))  # Coluna de email
    
    # Inicializando as variáveis da classe Escola (método construtor)
    def __init__(self, nome, endereco, telefone, email):
        self.nome = nome
        self.endereco = endereco
        self.telefone = telefone
        self.email = email

# Criando uma classe para representar a entidade Professor no banco de dados
class Professor(db.Model):
    # definindo atributos (colunas) da tabela Professor
    # Schema
    id = db.Column(db.Integer, primary_key=True)  # Coluna de ID, chave primária
    nome = db.Column(db.String(150))  # Coluna de nome
    cpf = db.Column(db.String(14))  # Coluna de CPF
    email = db.Column(db.String(100))  # Coluna de email
    telefone = db.Column(db.String(20))  # Coluna de telefone
    especialidade = db.Column(db.String(100))  # Coluna de especialidade (esporte)
    escola_id = db.Column(db.Integer, db.ForeignKey('escola.id'))  # Chave estrangeira para Escola
    
    # Inicializando as variáveis da classe Professor (método construtor)
    def __init__(self, nome, cpf, email, telefone, especialidade, escola_id):
        self.nome = nome
        self.cpf = cpf
        self.email = email
        self.telefone = telefone
        self.especialidade = especialidade
        self.escola_id = escola_id

# Criando uma classe para representar a entidade Aluno no banco de dados
class Aluno(db.Model):
    # definindo atributos (colunas) da tabela Aluno
    # Schema
    id = db.Column(db.Integer, primary_key=True)  # Coluna de ID, chave primária
    nome = db.Column(db.String(150))  # Coluna de nome
    cpf = db.Column(db.String(14))  # Coluna de CPF
    email = db.Column(db.String(100))  # Coluna de email
    telefone = db.Column(db.String(20))  # Coluna de telefone
    data_nascimento = db.Column(db.String(10))  # Coluna de data de nascimento (DD/MM/YYYY)
    esporte = db.Column(db.String(100))  # Coluna de esporte que pratica
    escola_id = db.Column(db.Integer, db.ForeignKey('escola.id'))  # Chave estrangeira para Escola
    professor_id = db.Column(db.Integer, db.ForeignKey('professor.id'))  # Chave estrangeira para Professor
    
    # Inicializando as variáveis da classe Aluno (método construtor)
    def __init__(self, nome, cpf, email, telefone, data_nascimento, esporte, escola_id, professor_id):
        self.nome = nome
        self.cpf = cpf
        self.email = email
        self.telefone = telefone
        self.data_nascimento = data_nascimento
        self.esporte = esporte
        self.escola_id = escola_id
        self.professor_id = professor_id