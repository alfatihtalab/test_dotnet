// Hashing passwords is a critical step in securing user data. Using a secure hashing algorithm ensures that passwords are not stored in plain text, making them less vulnerable to theft and misuse. In .NET, you can use libraries such as `BCrypt.Net` or `ASP.NET Core Identity` for hashing passwords securely.

// Here, I'll demonstrate how to hash passwords using both `BCrypt.Net` and the built-in capabilities of `ASP.NET Core Identity`.

// ### Using BCrypt.Net

// First, you need to install the `BCrypt.Net-Next` package. You can do this via the NuGet Package Manager or the command line:

// ```sh
// dotnet add package BCrypt.Net-Next
// ```

// Then, you can use the `BCrypt` class to hash and verify passwords.

// #### Example:

// ```csharp
// using BCrypt.Net;

// // Hash a password
// string password = "your_password";
// string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

// // Verify a password
// bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
// ```

// ### Using ASP.NET Core Identity

// If you are using ASP.NET Core Identity, password hashing is integrated into the framework. You'll typically use the `PasswordHasher` class.

// First, ensure you have the `Microsoft.AspNetCore.Identity` package installed:

// ```sh
// dotnet add package Microsoft.AspNetCore.Identity
// ```

// Then, use the `PasswordHasher<TUser>` class to hash and verify passwords.

// #### Example:

// ```csharp
// using Microsoft.AspNetCore.Identity;

// public class User
// {
//     public int Id { get; set; }
//     public string Username { get; set; }
//     public string PasswordHash { get; set; }
// }

// public class PasswordService
// {
//     private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

//     public string HashPassword(User user, string password)
//     {
//         return _passwordHasher.HashPassword(user, password);
//     }

//     public bool VerifyPassword(User user, string password)
//     {
//         var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
//         return result == PasswordVerificationResult.Success;
//     }
// }

// // Usage example
// var user = new User { Username = "testUser" };
// var passwordService = new PasswordService();

// string password = "your_password";
// user.PasswordHash = passwordService.HashPassword(user, password);

// bool isPasswordValid = passwordService.VerifyPassword(user, password);
// ```

// ### Integrating Password Hashing into the User Entity

// To integrate password hashing into your user entity and DbContext, you can modify the `User` class and the registration process.

// #### Modified User Class:

// ```csharp
// using System.ComponentModel.DataAnnotations;

// public class User
// {
//     [Key]
//     public int Id { get; set; }

//     [Required]
//     public string Username { get; set; }

//     [Required]
//     public string PasswordHash { get; set; }
// }
// ```

// #### User Registration Example:

// ```csharp
// public class UserService
// {
//     private readonly ApplicationContext _context;
//     private readonly PasswordService _passwordService;

//     public UserService(ApplicationContext context, PasswordService passwordService)
//     {
//         _context = context;
//         _passwordService = passwordService;
//     }

//     public void RegisterUser(string username, string password)
//     {
//         var user = new User { Username = username };
//         user.PasswordHash = _passwordService.HashPassword(user, password);
        
//         _context.Users.Add(user);
//         _context.SaveChanges();
//     }
// }

// // Example usage
// var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
// optionsBuilder.UseSqlServer("Your_Connection_String");

// var context = new ApplicationContext(optionsBuilder.Options);
// var passwordService = new PasswordService();
// var userService = new UserService(context, passwordService);

// userService.RegisterUser("testUser", "your_password");
// ```

// This example demonstrates how to hash passwords during user registration and verify passwords during authentication using both `BCrypt.Net` and `ASP.NET Core Identity`. Integrating password hashing securely is crucial for maintaining user data security in your applications.



