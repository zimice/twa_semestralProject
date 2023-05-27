import React, { useState } from 'react';

function Equipment({ equipment, onEdit }) {
  const [isEditing, setIsEditing] = useState(false);
  const [editName, setEditName] = useState(equipment.name);
  const [editDescription, setEditDescription] = useState(equipment.description);

  const handleEdit = () => {
    setIsEditing(true);
  }

  const handleSave = () => {
    onEdit(equipment.id, editName, editDescription);
    setIsEditing(false);
  }

  return (
    <div>
      {isEditing ? (
        <div>
          <input value={editName} onChange={(e) => setEditName(e.target.value)} />
          <input value={editDescription} onChange={(e) => setEditDescription(e.target.value)} />
          <button onClick={handleSave}>Save</button>
        </div>
      ) : (
        <div>
          <h2>{equipment.name}</h2>
          <p>{equipment.description}</p>
          <button onClick={handleEdit}>Edit</button>
        </div>
      )}
    </div>
  );
}

export default Equipment;
