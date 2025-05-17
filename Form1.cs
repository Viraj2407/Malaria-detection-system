public partial class Form1 : Form
{
    private string imagesDirectory;

    public Form1()
    {
        InitializeComponent();
        ShowWelcomeMessage();
        
        // Set up images directory
        imagesDirectory = Path.Combine(Application.StartupPath, "images");
        if (!Directory.Exists(imagesDirectory))
        {
            Directory.CreateDirectory(imagesDirectory);
        }
    }

    // When saving or accessing images, use this helper method
    private string GetImagePath(string filename)
    {
        return Path.Combine(imagesDirectory, filename);
    }

    // Use this when saving uploaded images
    private void SaveUploadedImage(string sourceFilePath)
    {
        try
        {
            string fileName = Path.GetFileName(sourceFilePath);
            string destinationPath = GetImagePath(fileName);
            File.Copy(sourceFilePath, destinationPath, true);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving image: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ShowWelcomeMessage()
    {
        MessageBox.Show("Welcome to Malaria Detection System\n\nThis system helps medical professionals detect malaria parasites in blood cell images.", 
            "Welcome", 
            MessageBoxButtons.OK, 
            MessageBoxIcon.Information);
    }
}