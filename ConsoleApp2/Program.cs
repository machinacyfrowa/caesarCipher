using System.Text;

string text; //tekst do zaszyfrowania
int key; //klucz - ilość znaków przesunięcia


string asciiCaesar(string t, int k)
{
    t = t.ToUpper();
    string encryptedText = ""; //zaszyfrowany tekst
    for (int i = 0; i < t.Length; i++)
    {
        char letter = t[i];
        int letterCode = (int)letter;
        letterCode += k;
        /*
        if (letterCode > 90)
            letterCode -= 26;
        */
        letterCode = ((letterCode - 65) % 26) + 65;
        char encryptedLetter = (char)letterCode;
        encryptedText += encryptedLetter;
    }
    return encryptedText;
}
string dictionaryCasesar(string t, int k)
{
    Dictionary<int, char> dictionary = new Dictionary<int, char>();
    for(int i = 65; i <= 90; i++)
    {
        int newIndex = dictionary.Count;
        dictionary.Add(newIndex, (char)i);
    }
    dictionary.Add(dictionary.Count, 'Ą');
    dictionary.Add(dictionary.Count, 'Ć');
    dictionary.Add(dictionary.Count, 'Ę');
    dictionary.Add(dictionary.Count, 'Ó');
    dictionary.Add(dictionary.Count, 'Ł');
    dictionary.Add(dictionary.Count, 'Ń');
    dictionary.Add(dictionary.Count, 'Ś');
    dictionary.Add(dictionary.Count, 'Ż');
    dictionary.Add(dictionary.Count, 'Ź');
    t = t.ToUpper();
    string encryptedText = ""; //zaszyfrowany tekst
    for (int i = 0; i < t.Length; i++)
    {
        int letterCode = dictionary.First(x => x.Value == t[i]).Key;
        int encryptedCode = letterCode + k;
        encryptedCode %= dictionary.Count-1;
        char encryptedChar = dictionary[encryptedCode];
        encryptedText += encryptedChar;
    }
    return encryptedText;
}
string byteCaesar(string t, int k)
{
    t = t.ToUpper();

    byte[] stringBytes = Encoding.ASCII.GetBytes(t);
    for (int i = 0; i < stringBytes.Length; i++)
    {
        int encryptedCode = (int)stringBytes[i];
        encryptedCode -= 65;
        encryptedCode += k;
        encryptedCode %= 26;
        encryptedCode += 65;
        stringBytes[i] = (byte)encryptedCode;
    }
    return Encoding.ASCII.GetString(stringBytes);
}

Console.WriteLine("Podaj tekst do zaszyfrowania");
text = Console.ReadLine() ?? "";
Console.WriteLine("Podaj klucz (wartość przesunięcia):");
key = int.Parse(Console.ReadLine() ?? "");



Console.WriteLine("Szyfrowanie ASCII: " + asciiCaesar(text, key));
Console.WriteLine("Szyfrowanie ASCII: " + dictionaryCasesar(text, key));
Console.WriteLine("Szyfrowanie ASCII: " + byteCaesar(text, key));
