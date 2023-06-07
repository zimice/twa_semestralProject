import React, { useState } from 'react';
import './EquipmentForm.css';

const EquipmentForm = ({ onSubmit }) => {
    const [name, setName] = useState("");
    const [desc, setDesc] = useState("");

    const handleSubmit = (event) => {
        event.preventDefault();
        onSubmit({ name, desc });
        setName("");
        setDesc("");
    }

    return (
        <form onSubmit={handleSubmit}>
            <label>
                Name:
                <input type="text" value={name} onChange={e => setName(e.target.value)} required />
            </label>
            <label>
                Type:
                <input type="text" value={desc} onChange={e => setDesc(e.target.value)} required />
            </label>
            <input type="submit" value="Submit" />
        </form>
    );
}

export default EquipmentForm;
