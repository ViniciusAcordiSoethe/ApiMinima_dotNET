namespace TodoStore.DB; // server para "APELIDAR" o arquivo 

 public record Todo // record é um tipo de classe que não precisa de construtor e nem de get e set
 {
   public int Id {get; set;} // get e set são os métodos de acesso
   public string ? Name { get; set; } // ? é para dizer que o campo é opcional ou que pode ser nulo 
 }

 public class TodoDB // classe que simula um banco de dados
 {
   private static List<Todo> _todo = new List<Todo>() // lista de todos
   {
    new Todo { Id = 1, Name = "Learn C#" },
    new Todo { Id = 2, Name = "Learn .NET" },
    new Todo { Id = 3, Name = "Learn EF Core" },
    new Todo { Id = 4, Name = "Learn SQL" },
    new Todo { Id = 5, Name = "Learn ASP.NET" },
    new Todo { Id = 6, Name = "Learn Blazor" },
   };

   public static List<Todo> GetTodoList() // método que retorna a lista de Todo
   {
     return _todo;
   } 

   public static Todo ? GetTodo(int id) // método que retorna um Todo específico
   {
     return _todo.SingleOrDefault(todo => todo.Id == id);
   } 

   public static Todo CreateTodo(Todo todo) // método que cria um Todo
   {
     _todo.Add(todo);
     return todo;
   }

   public static Todo UpdateTodo(Todo update) // método que atualiza um Todo
   {
     _todo = _todo.Select(todo =>
     {
       if (todo .Id == update.Id)
       {
         todo .Name = update.Name;
       }
       return todo ;
     }).ToList();
     return update;
   }

   public static void RemoveTodo(int id) // método que remove um Todo
   {
     _todo  = _todo.FindAll(todo  => todo .Id != id).ToList();
   }
 }
 