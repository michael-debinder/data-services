
namespace MetadataProcessor
{
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using Data;

    public partial class MetadataProcessor : Form
    {
        private Processing _processingForm;

        private bool _suspendSelectAllEntitiesCheckedChanged = false;

        private bool _suspendEntityCheckboxesItemCheck = false;

        public MetadataProcessor()
        {
            InitializeComponent();
        }

        private void MetadataProcessor_Load(object sender, System.EventArgs e)
        {
            var metadata = new Metadata();

            context.Text = metadata.Database.Connection.ConnectionString;

            tableSqlLoc.Text = ConfigurationManager.AppSettings["Folder_Tables"];
            entitiyPOCOsLoc.Text = ConfigurationManager.AppSettings["Folder_Entities"];
            entityPOCOAttrsLoc.Text = ConfigurationManager.AppSettings["Folder_Entities.Attrs"];
            entityTypesLoc.Text = ConfigurationManager.AppSettings["Folder_EntityTypes"];

            var query = from entity in metadata.EntityTypes
                        select entity;

            foreach (var entity in query.Where(et => !string.IsNullOrEmpty(et.StorageName)).OrderBy(et => et.Name))
            {
                entityCheckboxes.Items.Add(entity.Name);
            }
        }

        private void execute_Click(object sender, EventArgs e)
        {
            _processingForm = new Processing();
            _processingForm.EntityList = entityCheckboxes.CheckedItems.Cast<string>();

            _processingForm.TableSqlLoc = tableSql.Checked ? tableSqlLoc.Text : null;
            _processingForm.EntityPOCOsLoc = entitiyPOCOs.Checked ? entitiyPOCOsLoc.Text : null;
            _processingForm.EntityPOCOAttrsLoc = entityPOCOAttrs.Checked ? entityPOCOAttrsLoc.Text : null;
            _processingForm.EntityTypesLoc = entityTypes.Checked ? entityTypesLoc.Text : null;

            _processingForm.ShowDialog();
        }

        private void selectAllEntities_CheckedChanged(object sender, EventArgs e)
        {
            // Abort if we are suspending this event
            if (_suspendSelectAllEntitiesCheckedChanged)
            {
                return;
            }

            // Suspend the CheckedBoxList Event
            _suspendEntityCheckboxesItemCheck = true;

            // Update the checkboxes
            var check = selectAllEntities.Checked;
            for (var i = 0; i < entityCheckboxes.Items.Count; i++)
            {
                entityCheckboxes.SetItemChecked(i, check);
            }

            // Restore the CheckedBoxList Event
            _suspendEntityCheckboxesItemCheck = false;
        }

        private void entityCheckboxes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Abort if we are suspending this event
            if (_suspendEntityCheckboxesItemCheck)
            {
                return;
            }

            // Suspend the SelectAll Event
            _suspendSelectAllEntitiesCheckedChanged = true;

            // Manually determine the current count based on the Checked list and whether the current "click" is about to increment or decrement
            // Weird way to do this because no Event for Post-ItemCheck that is really reliable
            var checkCount = entityCheckboxes.CheckedItems.Count;
            if (e.NewValue == CheckState.Checked)
            {
                checkCount++;
            }
            else
            {
                checkCount--;
            }

            // Modify the value
            selectAllEntities.Checked = entityCheckboxes.Items.Count == checkCount;
            
            // Restore the SelectAll Event
            _suspendSelectAllEntitiesCheckedChanged = false;
        }
    }
}
