import React, { useEffect, useState } from 'react';

function EquipmentList() {
  const [equipment, setEquipment] = useState([]);

  useEffect(() => {
    fetch('/equipment')
      .then(response => response.json())
      .then(data => setEquipment(data));
  }, []);

  return (
    <ul>
      {equipment.map(item => (
        <li key={item.id}>{item.name}</li>
      ))}
    </ul>
  );
}

export default EquipmentList;
