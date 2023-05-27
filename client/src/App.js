import React, { useState, useEffect } from 'react';
import EquipmentList from './components/EquipmentList';
import EquipmentForm from './components/EquipmentForm';
import './App.css';

function App() {
  const [equipment, setEquipment] = useState(null);

  useEffect(() => {
    // Fetch the equipment from the server here and set it with setEquipment
    fetch('/equipment') // Assuming your API endpoint is '/api/equipment'
      .then(response => response.json())
      .then(data => setEquipment(data))
      .catch(error => console.error('Error:', error));
  }, []);

  const handleCreateEquipment = (newEquipment) => {
    // Send the new equipment to the server here and update the equipment state
    fetch('/equipment', {
      method: 'POST', 
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(newEquipment),
    })
    .then(response => response.json())
    .then(data => {
      // Assuming the server responds with the newly created equipment
      setEquipment([...equipment, data]);
    })
    .catch((error) => {
      console.error('Error:', error);
    });
  };

  if (equipment === null) return "Loading...";

  return (
    <div className="App">
      <EquipmentForm onSubmit={handleCreateEquipment} />
      <EquipmentList equipment={equipment} />
    </div>
  );
}

export default App;
