// Function to fetch data from the API and populate the HTML table
function fetchDataAndPopulateTable() {
    fetch('https://localhost:7007/api/data/table') // Replace with the correct API endpoint
        .then((response) => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then((data) => {
            const tableBody = document.getElementById('table-body'); // Get the table body element

            data.forEach((rowData) => {
                const row = document.createElement('tr'); // Create a new table row for each data item
                const keys = ['statioN_ID', 'sitE_NAME', 'state', 'city', 'address', 'clusteR_MEDIAN_PRICE', 'clienT_MARKET_PRICE'];

                keys.forEach((key) => {
                    const cell = document.createElement('td'); // Create a table cell for each key
                    cell.textContent = rowData[key]; // Use the uppercase key to access data
                    row.appendChild(cell); // Append the cell to the row
                });

                tableBody.appendChild(row); // Append the row to the table body
            });
        })
        .catch((error) => {
            console.error('Error loading data:', error);
        });
}

// Call the function to fetch data and populate the table when the page loads
if (!window.tableDataLoaded) { // Check if the event listener is already added
    window.addEventListener('load', fetchDataAndPopulateTable);
    window.tableDataLoaded = true; // Set a flag to indicate that the event listener is added
}
