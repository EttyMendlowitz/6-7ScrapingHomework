import React, { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';


const App = () => { 

    const [items, setItems] = useState([]);

    useEffect(() => {
        const getItems = async () => {
            const { data } = await axios.get('/api/scraping/getitems');
            setItems(data);
        }
        getItems();
    }, [])

    return (<div className='container mt-5'>
        <div className='row mt-3'>
            <table className='table table-bordered'>
                <thead>
                    <tr>
                        <th>Image</th>
                        <th>Title</th>
                        <th>Text</th>
                        <th>Comments</th>
                    </tr>
                </thead>
                <tbody>
                    {items.map(item => {
                        return <tr key={item.url}>
                            <td>
                                <img src={item.image} style={{ width: 200 }} /></td>
                            <td>
                                <a target="_blank" href={item.url}>{item.title}</a>
                            </td>
                            <td>
                                {item.text}
                            </td>
                            <td>
                                {item.comments }
                            </td>
                        </tr>
                    })}
                </tbody>
            </table>
        </div>
    </div>)
}

export default App;