\# 🔐 Secure Notes CLI

Secure Notes CLI is a simple command‑line application written in C# that
allows users to create and store encrypted notes locally. Each note is
encrypted using AES and a password‑derived key, ensuring that only the
correct password can decrypt the stored data.

\-\--

\## ✨ Features

\- Create encrypted notes - View previously saved notes - AES‑256
encryption - Password‑based key derivation (PBKDF2) - Notes stored in a
single encrypted file (\`notes.enc\`) - Simple and clean CLI interface

\-\--

\## 🛠 Technologies Used

\- C# (.NET) - AES Encryption - PBKDF2 (Rfc2898DeriveBytes) - JSON
Serialization

\-\--

\## 🚀 How It Works

1\. The user enters a password. 2. A key is derived from the password
using PBKDF2. 3. Notes are stored in a list and serialized to JSON. 4.
The JSON is encrypted using AES and saved to \`notes.enc\`. 5. When
reading notes, the same password must be used to decrypt the file.

\-\--

\## 📦 Running the Application

1\. Clone or download the project. 2. Open it in Visual Studio or VS
Code. 3. Build and run the project. 4. Enter a password when prompted.
5. Choose:  - \`1\` to write a note  - \`2\` to read notes  - \`3\` to
exit

\-\--

\## ⚠️ Important Notes

\- If you enter a different password than the one used to save the
notes, the file cannot be decrypted. - This project is for learning and
demonstration purposes, not production‑grade security.

\-\--

\## 📌 Future Improvements

\- Delete or edit notes - Search notes - Password strength checking -
Error handling for corrupted files - GUI version (WPF or WinForms)

\-\--

\## 📄 License

This project is licensed under the MIT License. See the \`LICENSE\` file
for details.
