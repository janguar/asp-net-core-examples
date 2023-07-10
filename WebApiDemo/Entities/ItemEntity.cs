namespace WebAPiDemo.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemEntity 
    { 
        /// <summary>
        /// Gets or sets the id.  
        /// </summary>
        private int _id = default;

        /// <summary>
        /// Gets or sets the id.  
        /// </summary> 
        public int Id {
            get => _id;
            set => _id = value;
        }

         
        /// <summary>
        /// Gets or sets the description.  
        /// </summary>
        private string _description = string.Empty;

        /// <summary>
        /// Gets or sets the description.  
        /// </summary> 
        public string Description {
            get => _description;
            set => _description = value;
        }
         
    }
}
