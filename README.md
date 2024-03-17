<h1>Documentação da API ToDo</h1>
A API ToDo fornece endpoints para gerenciar uma lista de tarefas (ToDo List).

Base URL
A URL base para acessar a API é: https://ToDoList

Endpoints
Listar todas as tarefas
Retorna uma lista de todas as tarefas.

URL:
GET /api/toDoList

Parâmetros de consulta opcionais:

status (string): Filtra as tarefas pelo status. Os valores possíveis são "pending", "progress" ou "complete".
minDate (string): Filtra as tarefas com data mínima igual ou posterior à data especificada (no formato "YYYY-MM-DD").
maxDate (string): Filtra as tarefas com data máxima igual ou anterior à data especificada (no formato "YYYY-MM-DD").
Exemplo de requisição:

[
  {
    "id": 1,
    "title": "Fazer compras",
    "Date": "03/04/2024,
    "description": "Comprar itens essenciais de supermercado",
    "status": "progress",
    
  },
  {
    "id": 2,
    "title": "Estudar para prova",
    "Date": "03/04/2024",
    "description": "Revisar matéria para a prova de matemática",
    "status": "progress",
    
  }
]

PUT /api/todo/{id}

Parâmetros de caminho:

id (int): ID da tarefa a ser atualizada.
Corpo da requisição (JSON):

[DELETE] Remover uma tarefa

Remove uma tarefa existente da lista de tarefas.
DELETE /api/todo/{id}
