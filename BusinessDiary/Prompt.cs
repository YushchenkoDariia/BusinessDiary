using System.Windows.Forms;

public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        Form prompt = new Form()
        {
            Width = 400,
            Height = 200,
            Text = caption
        };
        Label textLabel = new Label() { Text = text };
        TextBox textBox = new TextBox();
        Button confirmation = new Button() { Text = "OK" };
        confirmation.Click += (sender, e) => { prompt.Close(); };
        prompt.Controls.Add(textLabel);
        prompt.Controls.Add(textBox);
        prompt.Controls.Add(confirmation);
        prompt.ShowDialog();
        return textBox.Text;
    }
}