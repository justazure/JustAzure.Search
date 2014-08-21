using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using RedDog.Search;
using RedDog.Search.Http;
using RedDog.Search.Model;

namespace MovieSearch
{
    public partial class MainView : Form
    {
        private IndexManagementClient _managementClient;

        private IndexQueryClient _queryClient;

        public MainView()
        {
            InitializeComponent();
            InitSearch();
        }

        private void InitSearch()
        {
            var connection = ApiConnection.Create(ConfigurationManager.AppSettings["Azure.Search.ServiceName"],
                ConfigurationManager.AppSettings["Azure.Search.ApiKey"]);
            _managementClient = new IndexManagementClient(connection);
            _queryClient = new IndexQueryClient(connection);
        }

        private async void OnCreateIndex(object sender, EventArgs e)
        {
            var result = await _managementClient.CreateIndexAsync(new Index("imdb-movies")
                .WithStringField("id", opt =>
                    opt.IsKey().IsRetrievable())
                .WithStringField("title", opt =>
                    opt.IsRetrievable().IsSearchable())
                .WithStringField("description", opt =>
                    opt.IsRetrievable().IsSearchable())
                .WithDoubleField("rating", opt =>
                    opt.IsRetrievable().IsFilterable())
                .WithStringCollectionField("genre", opt =>
                    opt.IsRetrievable().IsFilterable().IsSearchable())
                );

            if (result.IsSuccess)
            {
                MessageBox.Show("Index created!");
            }
            else
            {
                MessageBox.Show("Error: " + result.Error.Message);
            }
        }

        private async void OnImportMovies(object sender, EventArgs e)
        {
            var result = await _managementClient.PopulateAsync("imdb-movies", new[]
            {
                new IndexOperation(IndexOperationType.Upload, "id", "tt0133093")
                    .WithProperty("title", "The Matrix")
                    .WithProperty("description", "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.")
                    .WithProperty("rating", 8.7)
                    .WithProperty("genre", new[] {"Action", "Sci-Fi"}),

                new IndexOperation(IndexOperationType.Upload, "id", "tt0159784")
                    .WithProperty("title", "Takedown")
                    .WithProperty("description", "This film is based on the story of the capture of computer hacker Kevin Mitnick.")
                    .WithProperty("rating", 6.3)
                    .WithProperty("genre", new[] {"Crime", "Drama", "Thriller"}),

                new IndexOperation(IndexOperationType.Upload, "id", "tt1285016")
                    .WithProperty("title", "The Social Network")
                    .WithProperty("description", "Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, but is later sued by two brothers who claimed he stole their idea, and the cofounder who was later squeezed out of the business.")
                    .WithProperty("rating", 7.8)
                    .WithProperty("genre", new[] {"Biography", "Drama"})
            });

            foreach (var record in result.Body.Where(r => !r.Status))
            {
                MessageBox.Show(String.Format("Error with record {0}: {1}", record.Key, record.ErrorMessage));

            }
        }

        private async void OnSearch(object sender, EventArgs e)
        {
            var query = new SearchQuery(textSearch.Text);
            if (!String.IsNullOrWhiteSpace(textGenre.Text))
                query.Filter = String.Format("genre/any(t: t eq '{0}')", textGenre.Text);

            var result = await _queryClient.SearchAsync("imdb-movies", query);

            var table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("title");
            table.Columns.Add("description");
            table.Columns.Add("rating");
            table.Columns.Add("genre");

            foreach (var record in result.Body.Records)
            {
                table.Rows.Add(new[]
                {
                    record.Properties["id"],
                    record.Properties["title"],
                    record.Properties["description"],
                    record.Properties["rating"],
                    record.Properties["genre"]
                });
            }

            gridView.DataSource = table;
        }
    }
}
