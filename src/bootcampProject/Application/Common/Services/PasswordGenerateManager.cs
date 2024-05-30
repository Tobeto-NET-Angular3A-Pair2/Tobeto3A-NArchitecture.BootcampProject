using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services;

public class PasswordGenerateManager : IPasswordGenerateService
{
    private const string Numbers = "0123456789";
    private const string LowercaseCharacters = "abcdefghijklmnopqrstuvwxyz";
    private const string UppercaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string SpecialCharacters = "!@#$%^&*()";
    private const string AllCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
    private int _length = 12;

    private readonly Random _random;

    public PasswordGenerateManager()
    {
        _random = new Random();
    }

    public string GetRandomPassword()
    {
        //Generate first 4 characters containing numbers, lowercase, uppercase and special characters
        string password = "";
        password += GetRandomCharacter(Numbers);
        password += GetRandomCharacter(LowercaseCharacters);
        password += GetRandomCharacter(UppercaseCharacters);
        password += GetRandomCharacter(SpecialCharacters);

        // Fill the remaining spaces with random characters
        for (int i = 0; i < _length - 4; i++)
        {
            password += GetRandomCharacter(AllCharacters);
        }

        // Arrange the generated password in random order
        string shuffledPassword = new string(password.ToCharArray().OrderBy(x => _random.Next()).ToArray());

        return shuffledPassword;
    }

    public string GetRandomPassword(int passwordLength)
    {
        //Generate first 4 characters containing numbers, lowercase, uppercase and special characters
        string password = "";
        password += GetRandomCharacter(Numbers);
        password += GetRandomCharacter(LowercaseCharacters);
        password += GetRandomCharacter(UppercaseCharacters);
        password += GetRandomCharacter(SpecialCharacters);

        // Fill the remaining spaces with random characters
        for (int i = 0; i < passwordLength - 4; i++)
        {
            password += GetRandomCharacter(AllCharacters);
        }

        // Arrange the generated password in random order
        string shuffledPassword = new string(password.ToCharArray().OrderBy(x => _random.Next()).ToArray());

        return shuffledPassword;
    }

    private char GetRandomCharacter(string characters)
    {
        var randomIndex = _random.Next(characters.Length);

        return characters[randomIndex];
    }
}
