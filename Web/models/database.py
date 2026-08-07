# Importando o Flask-SQLAlchemy
from flask_sqlalchemy import SQLAlchemy
# Carregando o SqlAlchemy em uma variável chamada db
db = SQLAlchemy()

class Aluno(db.Model):
    __tablename__ = 'aluno'
    id_aluno = db.Column(db.Integer, primary_key=True, autoincrement=True)
    usuario = db.Column(db.String(50), nullable=False)
    cpf = db.Column(db.String(18), unique=True, nullable=False)
    senha = db.Column(db.String(50), nullable=False)
    nome_responsavel = db.Column(db.String(50), nullable=True)
    telefone_responsavel = db.Column(db.String(50), nullable=True)
    cpf_responsavel = db.Column(db.String(18), nullable=True)
    rua = db.Column(db.String(50), nullable=True)
    bairro = db.Column(db.String(50), nullable=True)
    cidade = db.Column(db.String(50), nullable=True)
    estado = db.Column(db.String(50), nullable=True)
    num_casa = db.Column(db.Integer, nullable=True)

    def __init__(self, usuario, cpf, senha, nome_responsavel, telefone_responsavel, cpf_responsavel, rua, bairro, cidade, estado, num_casa):
        self.usuario = usuario
        self.cpf = cpf
        self.senha = senha
        self.nome_responsavel = nome_responsavel
        self.telefone_responsavel = telefone_responsavel
        self.cpf_responsavel = cpf_responsavel
        self.rua = rua
        self.bairro = bairro
        self.cidade = cidade
        self.estado = estado
        self.num_casa = num_casa

class Professor(db.Model):
    __tablename__ = 'professor'
    id_professor = db.Column(db.Integer, primary_key=True, autoincrement=True)
    usuario = db.Column(db.String(50), nullable=False)
    cpf = db.Column(db.String(18), unique=True, nullable=False)
    email = db.Column(db.String(50), unique=True, nullable=False)
    senha = db.Column(db.String(50), nullable=False)
    telefone = db.Column(db.String(50), nullable=True)
    rua = db.Column(db.String(50), nullable=True)
    bairro = db.Column(db.String(50), nullable=True)
    cidade = db.Column(db.String(50), nullable=True)
    estado = db.Column(db.String(50), nullable=True)
    num_casa = db.Column(db.Integer, nullable=True)

    def __init__(self, usuario, cpf, email, senha, telefone, rua, bairro, cidade, estado, num_casa):
        self.usuario = usuario
        self.cpf = cpf
        self.email = email
        self.senha = senha
        self.telefone = telefone
        self.rua = rua
        self.bairro = bairro
        self.cidade = cidade
        self.estado = estado
        self.num_casa = num_casa

class Escola(db.Model):
    __tablename__ = 'escola'
    cnpj = db.Column(db.String(18), primary_key=True)
    email = db.Column(db.String(50), nullable=True)
    usuario = db.Column(db.String(50), nullable=False)
    telefone = db.Column(db.String(50), nullable=True)
    rua = db.Column(db.String(50), nullable=True)
    bairro = db.Column(db.String(50), nullable=True)
    cidade = db.Column(db.String(50), nullable=True)
    estado = db.Column(db.String(50), nullable=True)

    def __init__(self, cnpj, email, usuario, telefone, rua, bairro, cidade, estado):
        self.cnpj = cnpj
        self.email = email
        self.usuario = usuario
        self.telefone = telefone
        self.rua = rua
        self.bairro = bairro
        self.cidade = cidade
        self.estado = estado

class Modalidade(db.Model):
    __tablename__ = 'modalidade'
    id_modalidade = db.Column(db.Integer, primary_key=True, autoincrement=True)
    nome = db.Column(db.String(25), nullable=False)
    vagas = db.Column(db.Integer, nullable=False)
    idade_min = db.Column(db.Integer, nullable=False)
    idade_max = db.Column(db.Integer, nullable=False)

    def __init__(self, nome, vagas, idade_min, idade_max):
        self.nome = nome
        self.vagas = vagas
        self.idade_min = idade_min
        self.idade_max = idade_max

class Turno(db.Model):
    __tablename__ = 'turno'
    id_turno = db.Column(db.Integer, primary_key=True, autoincrement=True)
    nome_turno = db.Column(db.String(25), nullable=False)

    def __init__(self, nome_turno):
        self.nome_turno = nome_turno

class Horario(db.Model):
    __tablename__ = 'horario'
    id_horario = db.Column(db.Integer, primary_key=True, autoincrement=True)
    id_modalidade = db.Column(db.Integer, db.ForeignKey('modalidade.id_modalidade'), nullable=False)
    id_professor = db.Column(db.Integer, db.ForeignKey('professor.id_professor'), nullable=False)
    id_turno = db.Column(db.Integer, db.ForeignKey('turno.id_turno'), nullable=False)
    dia_semana = db.Column(db.String(20), nullable=True)
    hora_inicio = db.Column(db.Time, nullable=True)
    hora_fim = db.Column(db.Time, nullable=True)

    modalidade = db.relationship('Modalidade', backref='horarios')
    professor = db.relationship('Professor', backref='horarios')
    turno = db.relationship('Turno', backref='horarios')

    def __init__(self, id_modalidade, id_professor, id_turno, dia_semana, hora_inicio, hora_fim):
        self.id_modalidade = id_modalidade
        self.id_professor = id_professor
        self.id_turno = id_turno
        self.dia_semana = dia_semana
        self.hora_inicio = hora_inicio
        self.hora_fim = hora_fim

class Matricula(db.Model):
    __tablename__ = 'matricula'
    id_matricula = db.Column(db.Integer, primary_key=True, autoincrement=True)
    id_aluno = db.Column(db.Integer, db.ForeignKey('aluno.id_aluno'), nullable=False)
    id_modalidade = db.Column(db.Integer, db.ForeignKey('modalidade.id_modalidade'), nullable=False)
    data_matricula = db.Column(db.Date, nullable=True)

    aluno = db.relationship('Aluno', backref='matriculas')
    modalidade = db.relationship('Modalidade', backref='matriculas')

    def __init__(self, id_aluno, id_modalidade, data_matricula):
        self.id_aluno = id_aluno
        self.id_modalidade = id_modalidade
        self.data_matricula = data_matricula

class Presenca(db.Model):
    __tablename__ = 'presenca'
    id_presenca = db.Column(db.Integer, primary_key=True, autoincrement=True)
    id_aluno = db.Column(db.Integer, db.ForeignKey('aluno.id_aluno'), nullable=False)
    id_horario = db.Column(db.Integer, db.ForeignKey('horario.id_horario'), nullable=False)
    data_presenca = db.Column(db.Date, nullable=False)
    status = db.Column(db.Enum('Presente', 'Faltou', 'Justificado', name='status_presenca'), nullable=False)

    aluno = db.relationship('Aluno', backref='presencas')
    horario = db.relationship('Horario', backref='presencas')

    def __init__(self, id_aluno, id_horario, data_presenca, status):
        self.id_aluno = id_aluno
        self.id_horario = id_horario
        self.data_presenca = data_presenca
        self.status = status
