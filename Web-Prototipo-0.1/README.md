# Sistema de Cadastro de Esportes

Um sistema web para gerenciar cadastro de alunos, professores e escolas de esportes.

## Estrutura do Projeto

```
Web-Prototipo-0.1/
├── app.py                  # Arquivo principal da aplicação
├── controllers/
│   └── routes.py           # Definição das rotas
├── models/
│   └── database.py         # Definição dos modelos de banco de dados
├── views/
│   ├── base.html           # Template base
│   ├── index.html          # Página inicial
│   ├── escolas.html        # Gerenciamento de escolas
│   ├── professores.html    # Gerenciamento de professores
│   ├── alunos.html         # Gerenciamento de alunos
│   └── detalhes_escola.html # Detalhes de uma escola
├── static/
│   └── css/
│       └── style.css       # Estilos CSS
└── README.md               # Este arquivo
```

## Requisitos

- Python 3.7+
- MySQL Server
- Flask
- Flask-SQLAlchemy
- PyMySQL

## Instalação

### 1. Criar um ambiente virtual (opcional, mas recomendado)

```bash
python -m venv venv
source venv/bin/activate  # No Windows: venv\Scripts\activate
```

### 2. Instalar dependências

```bash
pip install flask flask-sqlalchemy pymysql
```

### 3. Configurar Banco de Dados

Certifique-se de que o MySQL está rodando na sua máquina.

## Execução

### 1. Iniciar a aplicação

```bash
python app.py
```

Na primeira execução, o banco de dados será criado automaticamente.

### 2. Acessar a aplicação

Abra seu navegador e acesse: `http://localhost:5000`

## Funcionalidades

### Escolas
- Listar todas as escolas
- Cadastrar nova escola
- Visualizar detalhes da escola (professores e alunos)
- Deletar escola

### Professores
- Listar todos os professores
- Cadastrar novo professor
- Associar professor a uma escola
- Definir especialidade (esporte)
- Deletar professor

### Alunos
- Listar todos os alunos
- Cadastrar novo aluno
- Associar aluno a uma escola
- Associar aluno a um professor
- Definir esporte praticado
- Deletar aluno

## Modelos de Dados

### Escola
- `id` (PK)
- `nome`
- `endereco`
- `telefone`
- `email`

### Professor
- `id` (PK)
- `nome`
- `cpf`
- `email`
- `telefone`
- `especialidade` (esporte)
- `escola_id` (FK)

### Aluno
- `id` (PK)
- `nome`
- `cpf`
- `email`
- `telefone`
- `data_nascimento`
- `esporte`
- `escola_id` (FK)
- `professor_id` (FK)

## Navegação

A barra de navegação permite acessar:
- **Início**: Página inicial com atalhos
- **Escolas**: Gerenciamento de escolas
- **Professores**: Gerenciamento de professores
- **Alunos**: Gerenciamento de alunos

## Banco de Dados

- Nome do banco: `esportesdb`
- Usuário: `root`
- Senha: (vazia por padrão)
- Host: `localhost`

Para alterar as configurações do banco de dados, edite o arquivo `app.py`.

## Autor

Projeto desenvolvido como sistema de cadastro para gerenciar pessoas em esportes.
