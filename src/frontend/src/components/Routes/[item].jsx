import { Link } from "react-router-dom";
import { ArrowBackIcon } from "../Icons";

function callGet()
{
  fetch('http://localhost:5000/dashboards')  // Replace with your API endpoint
  .then(response => {
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
    return response.json(); // Parse the response body as JSON
  })
  .then(data => {
    console.log('Data received:', data);
    // Do something with the data (e.g., display it on the page)
  })
  .catch(error => {
    console.error('Fetch error:', error);
    // Handle errors (e.g., display an error message to the user)
  });
}

const Item = (props) => {
  const { page } = props;
  if (page === "homepage") {
    return <div id="page">{page}</div>;
  } else {
    return 
    (
      callGet(),
      <div id="page">
        
        {page}
      </div>
    );
  }
};

export default Item;
