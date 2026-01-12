using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SecureNotesCLI.Models;

namespace SecureNotesCLI.Services
{
    public class FileService
    {
        private readonly EncryptionService _encryption;
        private readonly KeyService _keyService;
        private readonly string filePath = "notes.enc";

        public FileService(EncryptionService encryption, KeyService keyService)
        {
            _encryption = encryption;
            _keyService = keyService;
        }

        public void AddNote(Note note, string password)
        {
            var notes = LoadNotes(password);
            notes.Add(note);
            SaveNotes(notes, password);
        }

        public List<Note> LoadNotes(string password)
        {
            if (!File.Exists(filePath))
                return new List<Note>();

            byte[] fileBytes = File.ReadAllBytes(filePath);
            byte[] salt = fileBytes[..16];
            byte[] iv = fileBytes[16..32];
            byte[] cipher = fileBytes[32..];

            byte[] key = _keyService.DeriveKey(password, salt);
            string json = _encryption.Decrypt(cipher, key, iv);
            return JsonSerializer.Deserialize<List<Note>>(json);
        }

        private void SaveNotes(List<Note> notes, string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] iv = RandomNumberGenerator.GetBytes(16);
            byte[] key = _keyService.DeriveKey(password, salt);

            string json = JsonSerializer.Serialize(notes);
            byte[] cipher = _encryption.Encrypt(json, key, iv);

            byte[] final = salt.Concat(iv).Concat(cipher).ToArray();
            File.WriteAllBytes(filePath, final);
        }
    }
}