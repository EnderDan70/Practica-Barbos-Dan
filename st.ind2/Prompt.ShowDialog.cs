using System.Windows.Forms;

public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        Form prompt = new Form()
        {
            Width = 300,
            Height = 150,
            Text = caption
        };
        Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 240 };
        TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 240 };
        Button confirmation = new Button() { Text = "OK", Left = 180, Width = 80, Top = 80, DialogResult = DialogResult.OK };
        prompt.Controls.Add(textLabel);
        prompt.Controls.Add(inputBox);
        prompt.Controls.Add(confirmation);
        prompt.AcceptButton = confirmation;

        return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
    }
}
