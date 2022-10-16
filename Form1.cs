namespace InventoryApp2
{
    public partial class Form1 : Form
    {
        //List to hold Shoe objects. It shares corresponding index with listbox. Indext [0] in shoeslist corresponds to indext [0] listbox etc..
        List<Shoe> shoeList = new List<Shoe>();
        
        public Form1()
        {
            InitializeComponent();
        }
        //The getShoeData method accepts a Shoe object as an argument. It assigns the data entered by the user to the object properties
        private void getShoeData(Shoe theShoe)
        {
            //Temporary variable to hold the price.
            decimal price;

            //Get the shoe brand.
            theShoe.Brand = brandInputTextBox1.Text;

            //Get the shoe model.
            theShoe.Model = modelInputTextBox2.Text;

            //Get the shoe price.
            if (decimal.TryParse(priceInputTextBox3.Text, out price))
            {
                theShoe.Price = price;
            }
            else
            {
                //Display an error message
                MessageBox.Show("Invalid price");
            }

        }

        private void addShoeButton1_Click(object sender, EventArgs e)
        {
            //Create a shoe object.
            Shoe myShoe = new Shoe();

            //Get the shoe data.
            getShoeData(myShoe);
            //Add the shoe object to the list.
            shoeList.Add(myShoe);

            //int i = shoeList.lenght();

            //Add an entry to the list box.
            shoeOutputListBox1.Items.Add(myShoe.Brand + " " + myShoe.Model + " " + "$"+myShoe.Price);

            //Clear the textbox controls.
            brandInputTextBox1.Clear();
            modelInputTextBox2.Clear();
            priceInputTextBox3.Clear();

            //Reset the focus.
            brandInputTextBox1.Focus();



        }

       private void shoeOutputListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the index of the selected item.
            //int index = shoeOutputListBox1.SelectedIndex;

            //Display the select item price.
            //MessageBox.Show(shoeList[index].Price.ToString("c"));

        }

        private void exitButton2_Click(object sender, EventArgs e)
        {
            //Close the form.
            this.Close();

        }

        private void deleteButton3_Click(object sender, EventArgs e)
        {
            //Create a shoe object.
            Shoe deleteShoe = new Shoe();

            

            //if listbox is empty
            if (shoeOutputListBox1.SelectedIndex == -1)
                MessageBox.Show("Select an item.");

                // if the listbox is not empty, -1 means empty
             if (shoeOutputListBox1.SelectedIndex >-1)

            //Removes the selected item in listbox.
            shoeOutputListBox1.Items.RemoveAt(shoeOutputListBox1.SelectedIndex);

            //shoeOutputListBox1.Items.Clear();

        }

        private void inventoryTotalButton4_Click(object sender, EventArgs e)
        {
            if (shoeOutputListBox1.Items.Count == 0)  //if the listbox count is equal to 0.
            {
                MessageBox.Show("There are no items in the list"); // show alert message
                inventoryTotalTextBox1.Clear();  //then clear the textbox inventory
            }
            else
            {
                int shoeInventory = shoeOutputListBox1.Items.Count; //gets the count of the listbox and assigns it to shoeInventory variable
                inventoryTotalTextBox1.Text = shoeInventory.ToString(); // Converts the integer variable to string and assigns it to inventoryTotalTextBox1.
                

            }
            

        }
    }
}