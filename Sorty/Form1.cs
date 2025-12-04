using System;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml; // EPPlus Library
using FuzzySharp;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RestSharp;
using System.Text.Json; // Wichtig für das Laden der Secrets

namespace Sorty
{
    public partial class Form1 : Form
    {
        private string excelFilePath;

        public Form1()
        {
            InitializeComponent();

            cB_Ort.SelectedIndex = 0;
            dGV_Results.AllowUserToAddRows = false;

            // Fix für möglichen Null-Reference Fehler beim Start, falls Columns noch nicht existieren
            if (dGV_Results.Columns["Namen"] != null)
            {
                dGV_Results.Columns["Namen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dGV_Results.RowHeadersVisible = false;

            dGV_Results.BorderStyle = BorderStyle.None;
            dGV_Results.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
            dGV_Results.DefaultCellStyle.Font = new Font("Barlow Condensed", 20);
            dGV_Results.RowTemplate.Height = 35;

            // Lizenzkontext setzen
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string appFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(appFolder);

            excelFilePath = Path.Combine(appFolder, "Orders.xlsx");

            if (!File.Exists(excelFilePath))
            {
                CreateInitialExcelFile();
            }

            UpdateLagerStats();
            SetFocusToLastName();
        }

        private void RemoveNameFromExcel(string name, string ort)
        {
            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets["Orders"];
                if (worksheet.Dimension != null)
                {
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        if (worksheet.Cells[row, 1].Value?.ToString() == name && worksheet.Cells[row, 3].Value?.ToString() == ort)
                        {
                            worksheet.DeleteRow(row);
                            break;
                        }
                    }
                }
                package.Save();
            }
            UpdateLagerStats();
        }

        private void SaveToArchive(string name, string vorname, string ort, int chestNumber)
        {
            string archivePath = Path.Combine(Path.GetDirectoryName(excelFilePath), "Abholungen.xlsx");

            using (var package = new ExcelPackage(new FileInfo(archivePath)))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault() ?? package.Workbook.Worksheets.Add("Abholungen");

                int newRow = worksheet.Dimension?.Rows + 1 ?? 2;
                worksheet.Cells[newRow, 1].Value = name;
                worksheet.Cells[newRow, 2].Value = vorname;
                worksheet.Cells[newRow, 3].Value = ort;
                worksheet.Cells[newRow, 4].Value = chestNumber;
                worksheet.Cells[newRow, 5].Value = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

                package.Save();
            }
        }

        private void CreateInitialExcelFile()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Orders");
                worksheet.Cells[1, 1].Value = "Name";
                worksheet.Cells[1, 2].Value = "Vorname";
                worksheet.Cells[1, 3].Value = "Ort";
                worksheet.Cells[1, 4].Value = "Kisten Nummer";
                worksheet.Cells[1, 5].Value = "Preis";
                package.SaveAs(new FileInfo(excelFilePath));
            }
        }

        private void SaveOrder(string name, string vorname, string ort, int chestNumber, double price)
        {
            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets["Orders"];
                int newRow = worksheet.Dimension?.Rows + 1 ?? 2;
                worksheet.Cells[newRow, 1].Value = name;
                worksheet.Cells[newRow, 2].Value = vorname;
                worksheet.Cells[newRow, 3].Value = ort;
                worksheet.Cells[newRow, 4].Value = chestNumber;
                worksheet.Cells[newRow, 5].Value = price;
                package.Save();
            }
        }

        private void SetFocusToLastName()
        {
            if (tB_AddName != null) tB_AddName.Focus();
        }

        private void BTN_AddSave_Click(object sender, EventArgs e)
        {
            string name = tB_AddName.Text;
            string vorname = tB_Vorname.Text;
            string? ort = cB_Ort.SelectedItem?.ToString();

            int ChestNumber = 0;
            double price = 0;

            if (!int.TryParse(tB_Kiste.Text, out ChestNumber) || !double.TryParse(tB_Price.Text, out price))
            {
                MessageBox.Show("Bitte gültige Zahlen für Kiste und Preis eingeben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ort) || ChestNumber == 0 || price == 0)
            {
                MessageBox.Show("Bitte alle Felder ausfüllen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveOrder(name, vorname, ort, ChestNumber, price);
            MessageBox.Show("Bestellung gespeichert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tB_AddName.Clear();
            tB_Vorname.Clear();
            tB_Kiste.Clear();
            tB_Price.Clear();
            cB_Ort.SelectedIndex = 0;

            UpdateLagerStats();
            SetFocusToLastName();
        }

        private void btnClearExcel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Möchten Sie wirklich alle Daten in der Excel-Datei löschen?", "Bestätigung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ClearExcelFile();
                MessageBox.Show("Die Excel-Datei wurde geleert.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateLagerStats();
        }

        private void ClearExcelFile()
        {
            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets["Orders"];
                worksheet.DeleteRow(2, worksheet.Dimension?.Rows - 1 ?? 0);
                package.Save();
            }

            string archivePath = Path.Combine(Path.GetDirectoryName(excelFilePath), "Abholungen.xlsx");
            if (File.Exists(archivePath))
            {
                using (var package = new ExcelPackage(new FileInfo(archivePath)))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault() ?? package.Workbook.Worksheets.Add("Abholungen");
                    worksheet.DeleteRow(2, worksheet.Dimension?.Rows - 1 ?? 0);
                    package.Save();
                }
            }
        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            if (File.Exists(excelFilePath))
            {
                try
                {
                    var processStartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = excelFilePath,
                        UseShellExecute = true
                    };
                    System.Diagnostics.Process.Start(processStartInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Die Datei konnte nicht geöffnet werden: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Die Excel-Datei wurde nicht gefunden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateLagerStats();
        }

        private void BTN_NamenEintragen_Click(object sender, EventArgs e)
        {
            p_NamenEintragen.Visible = true;
            p_SearchName.Visible = false;
            SetFocusToLastName();
            UpdateLagerStats();
        }

        private void BTN_NamenSuchen_Click(object sender, EventArgs e)
        {
            p_NamenEintragen.Visible = false;
            p_SearchName.Visible = true;
            UpdateLagerStats();
        }

        private void tB_SearchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                btnSearchName_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // --- Soundex Helper ---
        public static class Soundex
        {
            public static string Generate(string input)
            {
                if (string.IsNullOrEmpty(input)) return string.Empty;
                char firstLetter = char.ToUpper(input[0]);
                string tail = input.Substring(1).ToUpper();
                tail = Regex.Replace(tail, "[BFPV]", "1");
                tail = Regex.Replace(tail, "[CGJKQSXZ]", "2");
                tail = Regex.Replace(tail, "[DT]", "3");
                tail = Regex.Replace(tail, "[L]", "4");
                tail = Regex.Replace(tail, "[MN]", "5");
                tail = Regex.Replace(tail, "[R]", "6");
                tail = Regex.Replace(tail, "[AEIOUHWY]", "");
                tail = Regex.Replace(tail, @"(\d)\1+", "$1");
                string soundex = firstLetter + tail;
                return soundex.PadRight(4, '0').Substring(0, 4);
            }
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            string inputName = tB_SearchName.Text;

            if (string.IsNullOrWhiteSpace(inputName))
            {
                MessageBox.Show("Bitte einen Namen eingeben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var similarNames = SearchNames(inputName);

            dGV_Results.Rows.Clear();
            foreach (var result in similarNames)
            {
                dGV_Results.Rows.Add(result.Name, result.Vorname, result.Ort, result.ChestNumber, $"{result.Similarity}%");
            }
            UpdateLagerStats();
        }

        private List<(string Name, string vorname, string Ort, int ChestNumber)> GetAllNamesFromExcel()
        {
            List<(string Name, string vorname, string Ort, int ChestNumber)> names = new List<(string Name, string vorname, string Ort, int ChestNumber)>();

            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets["Orders"];
                if (worksheet.Dimension != null)
                {
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        string? name = worksheet.Cells[row, 1].Value?.ToString();
                        string? vorname = worksheet.Cells[row, 2].Value?.ToString();
                        string? ort = worksheet.Cells[row, 3].Value?.ToString();

                        // Sicheres Parsen der Int-Werte
                        int chestNumber = 0;
                        if (worksheet.Cells[row, 4].Value != null)
                            int.TryParse(worksheet.Cells[row, 4].Value.ToString(), out chestNumber);

                        if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(ort))
                        {
                            names.Add((name, vorname, ort, chestNumber));
                        }
                    }
                }
            }
            return names;
        }

        private List<(string Name, string Vorname, string Ort, int ChestNumber, int Similarity)> SearchNames(string inputName)
        {
            string inputSoundex = Soundex.Generate(inputName);
            List<(string Name, string Vorname, string Ort, int ChestNumber)> names = GetAllNamesFromExcel();

            var results = names.Select(entry =>
            {
                string name = entry.Name;
                string vorname = entry.Vorname;
                bool containsInput = name.IndexOf(inputName, StringComparison.OrdinalIgnoreCase) >= 0;
                int levenshteinSimilarity = Fuzz.Ratio(inputName, name);
                bool isPhoneticMatch = Soundex.Generate(name) == inputSoundex;
                int priority = containsInput ? 100 : (isPhoneticMatch ? 10 : 0);
                int totalScore = priority + levenshteinSimilarity;

                return (Name: name, Vorname: vorname, Ort: entry.Ort, ChestNumber: entry.ChestNumber, Similarity: Math.Min(totalScore, 100));
            })
            .Where(result => result.Similarity >= 35)
            .OrderByDescending(result => result.Similarity)
            .ToList();

            return results;
        }

        private void dGV_Results_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dGV_Results.Columns["Name"]?.Index)
            {
                var cellValue = dGV_Results.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (!string.IsNullOrEmpty(cellValue))
                {
                    e.ToolTipText = cellValue;
                }
            }
        }

        private void dGV_Results_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sicherstellen, dass die Spalte existiert, um Absturz zu vermeiden
            if (dGV_Results.Columns["Delete"] != null && e.ColumnIndex == dGV_Results.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                var name = dGV_Results.Rows[e.RowIndex].Cells["Namen"].Value.ToString();
                var vorname = dGV_Results.Rows[e.RowIndex].Cells["Vorname"].Value.ToString();
                var ort = dGV_Results.Rows[e.RowIndex].Cells["Orte"].Value.ToString();
                var chestNumber = Convert.ToInt32(dGV_Results.Rows[e.RowIndex].Cells["Number"].Value);
                var price = GetPriceFromExcel(name, ort, chestNumber);

                RemoveNameFromExcel(name, ort);
                dGV_Results.Rows.RemoveAt(e.RowIndex);

                MessageBox.Show($"{name} wurde abgeholt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- BOT LOGIK ---
                // Hier fangen wir jetzt Fehler sichtbar ab
                try
                {
                    var bot = new DiscordBot();
                    bot.SendPickupNotification(name, vorname, chestNumber, ort, price);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Initialisieren des Bots: " + ex.Message);
                }
                // -----------------

                SaveToArchive(name, vorname, ort, chestNumber);
                UpdateLagerStats();
            }
        }

        private double GetPriceFromExcel(string name, string ort, int chestNumber)
        {
            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets["Orders"];
                if (worksheet.Dimension != null)
                {
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        string excelName = worksheet.Cells[row, 1].Value?.ToString();
                        string excelOrt = worksheet.Cells[row, 3].Value?.ToString();

                        int excelChestNumber = 0;
                        if (worksheet.Cells[row, 4].Value != null)
                            int.TryParse(worksheet.Cells[row, 4].Value.ToString(), out excelChestNumber);

                        double excelPrice = 0;
                        if (worksheet.Cells[row, 5].Value != null)
                            double.TryParse(worksheet.Cells[row, 5].Value.ToString(), out excelPrice);

                        if (excelName == name && excelOrt == ort && excelChestNumber == chestNumber)
                        {
                            return excelPrice;
                        }
                    }
                }
            }
            return 0.0;
        }

        // --- Analyse Stats ---

        int Lager1;
        int Lager2;
        int Lager3;
        int AllLager;

        private Dictionary<string, int> GetLagerCounts()
        {
            var counts = new Dictionary<string, int>();

            if (!File.Exists(excelFilePath)) return counts;

            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets["Orders"];
                if (worksheet.Dimension != null)
                {
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        string? ort = worksheet.Cells[row, 3].Value?.ToString();
                        if (string.IsNullOrWhiteSpace(ort)) continue;

                        if (!counts.ContainsKey(ort)) counts[ort] = 0;
                        counts[ort]++;
                    }
                }
            }
            return counts;
        }

        private void UpdateLagerStats()
        {
            var counts = GetLagerCounts();
            Lager1 = counts.GetValueOrDefault("Lager 1", 0);
            Lager2 = counts.GetValueOrDefault("Lager 2", 0);
            Lager3 = counts.GetValueOrDefault("Lager 3", 0);
            AllLager = Lager1 + Lager2 + Lager3;

            l_L1Number.Text = Lager1.ToString();
            l_L2Number.Text = Lager2.ToString();
            l_L3Number.Text = Lager3.ToString();
            l_AllLagerNumber.Text = AllLager.ToString();
        }

        private List<(string Name, string vorname, string Ort, int ChestNumber)> GetAllEntriesAlphabetical()
        {
            var entries = new List<(string Name, string vorname, string Ort, int ChestNumber)>();

            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets["Orders"];
                if (worksheet.Dimension != null)
                {
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        string? name = worksheet.Cells[row, 1]?.Value?.ToString();
                        string? vorname = worksheet.Cells[row, 2]?.Value?.ToString();
                        string? ort = worksheet.Cells[row, 3]?.Value?.ToString();

                        int chestNumber = 0;
                        if (worksheet.Cells[row, 4]?.Value != null)
                            int.TryParse(worksheet.Cells[row, 4].Value.ToString(), out chestNumber);

                        if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(ort))
                        {
                            entries.Add((name, vorname, ort, chestNumber));
                        }
                    }
                }
            }
            return entries.OrderBy(entry => entry.Name).ToList();
        }

        private void BTN_All_Click(object sender, EventArgs e)
        {
            var allEntries = GetAllEntriesAlphabetical();
            dGV_Results.Rows.Clear();
            foreach (var entry in allEntries)
            {
                dGV_Results.Rows.Add(entry.Name, entry.vorname, entry.Ort, entry.ChestNumber, "X");
            }
        }

        private void checkForSave()
        {
            if (tB_AddName_Selected && tB_Kiste_Selected && tB_Price_Selected && cB_Ort_Selected)
            {
                BTN_AddSave.Enabled = true;
                BTN_AddSave.BackColor = Color.White;
            }
            else
            {
                BTN_AddSave.Enabled = false;
                BTN_AddSave.BackColor = Color.DarkGray;
            }
        }

        bool tB_AddName_Selected = false;
        private void tB_AddName_TextChanged(object sender, EventArgs e)
        {
            tB_AddName_Selected = tB_AddName.Text.Length > 0;
            checkForSave();
        }
        bool tB_Kiste_Selected = false;
        private void tB_Kiste_TextChanged(object sender, EventArgs e)
        {
            tB_Kiste_Selected = tB_Kiste.Text.Length > 0;
            checkForSave();
        }
        bool tB_Price_Selected = false;
        private void tB_Price_TextChanged(object sender, EventArgs e)
        {
            tB_Price_Selected = tB_Price.Text.Length > 0;
            checkForSave();
        }
        bool cB_Ort_Selected = false;
        private void cB_Ort_SelectedIndexChanged(object sender, EventArgs e)
        {
            cB_Ort_Selected = cB_Ort.Text.Length > 0;
            checkForSave();
        }

        private void BTN_Open_Abgeholten_Click(object sender, EventArgs e)
        {
            string archivePath = Path.Combine(Path.GetDirectoryName(excelFilePath), "Abholungen.xlsx");
            if (File.Exists(archivePath))
            {
                try
                {
                    var processStartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = archivePath,
                        UseShellExecute = true
                    };
                    System.Diagnostics.Process.Start(processStartInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Die Datei konnte nicht geöffnet werden: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Die Excel-Datei wurde nicht gefunden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateLagerStats();
        }

        // --- DISCORD CONFIGURATION & BOT ---

        public class BotConfig
        {
            public string DiscordToken { get; set; }
            public string ChannelId { get; set; }
        }

        public class DiscordBot
        {
            private string botToken;
            private string channelId;

            public DiscordBot()
            {
                LoadConfig();
            }

            private void LoadConfig()
            {
                try
                {
                    string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "secrets.json");

                    if (File.Exists(configPath))
                    {
                        string jsonString = File.ReadAllText(configPath);
                        // Case-Insensitive, falls User das JSON klein schreibt
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var config = JsonSerializer.Deserialize<BotConfig>(jsonString, options);

                        if (config != null)
                        {
                            botToken = config.DiscordToken;
                            channelId = config.ChannelId;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Konfiguration nicht gefunden!\nPfad: {configPath}\n\nBitte sicherstellen, dass secrets.json existiert und 'Ins Ausgabeverzeichnis kopieren' aktiviert ist.", "Bot Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Lesen der secrets.json: {ex.Message}", "Bot Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public void SendPickupNotification(string name, string vorname, int chestNumber, string location, double price)
            {
                if (string.IsNullOrEmpty(botToken) || string.IsNullOrEmpty(channelId))
                {
                    MessageBox.Show("Bot Token oder Channel ID fehlen. Bitte secrets.json prüfen.", "Bot Konfiguration fehlt");
                    return;
                }

                var client = new RestClient($"https://discord.com/api/v10/channels/{channelId}/messages");
                var request = new RestRequest
                {
                    Method = Method.Post
                };

                request.AddHeader("Authorization", $"Bot {botToken}");
                request.AddHeader("Content-Type", "application/json");

                string message = $"📦 **Neue Abholung** ({DateTime.Now:dd.MM.yyyy HH:mm})\n" +
                                 $"👤 **Name:** {name}, {vorname}\n" +
                                 $"🏠 **Lager:** {location}\n" +
                                 $"🔢 **Kiste:** {chestNumber}\n" +
                                 $"💰 **Preis:** {price:C}";

                var payload = new { content = message };
                request.AddJsonBody(payload);

                // Hier machen wir den Call asynchron, aber warten darauf (damit wir Fehler sehen)
                var response = client.Execute(request);

                if (!response.IsSuccessful)
                {
                    MessageBox.Show($"Fehler beim Senden an Discord:\nStatus: {response.StatusCode}\nNachricht: {response.Content}", "Discord API Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Erfolgsnachricht sparen wir uns, das nervt sonst bei jeder Abholung
            }
        }

        private void ShowLager(string lager)
        {
            var allData = GetAllNamesFromExcel();
            var filteredData = allData
                .Where(entry => entry.Ort == lager)
                .OrderBy(entry => entry.Name)
                .ThenBy(entry => entry.vorname)
                .ToList();

            dGV_Results.Rows.Clear();
            foreach (var data in filteredData)
            {
                dGV_Results.Rows.Add(data.Name, data.vorname, data.Ort, data.ChestNumber, "X");
            }
        }

        private void BTN_ShowL1_Click(object sender, EventArgs e)
        {
            ShowLager("Lager 1");
        }

        private void BTN_ShowL2_Click(object sender, EventArgs e)
        {
            ShowLager("Lager 2");
        }

        private void BTN_ShowL3_Click(object sender, EventArgs e)
        {
            ShowLager("Lager 3");
        }
    }
}