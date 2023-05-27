const express = require("express");
const sqlite3 = require('sqlite3').verbose();

let db = new sqlite3.Database('./hospitalER.db', (err) => {
  if (err) {
    console.error(err.message);
  }
  console.log('Connected to the hospital-er-app database.');
});


const PORT = process.env.PORT || 3001;

const app = express();

app.get("/equipment", (req, res) => {
    const sql = "SELECT * FROM equipment";
    db.all(sql, [], (err, rows) => {
      if (err) {
        return console.error(err.message);
      }
      res.json(rows);
    });
  });


// POST method route
app.post("/equipment", (req, res) => {
    const {name, description, quantity} = req.body;
    db.run(`INSERT INTO equipment (name, description, quantity) VALUES(?, ?, ?)`, [name, description, quantity], function(err) {
      if (err) {
        return console.log(err.message);
      }
      // get the last insert id
      console.log(`A row has been inserted with rowid ${this.lastID}`);
    });
    res.status(201).send('Equipment added');
  });
  
  // PUT method route
  app.put("/equipment/:id", (req, res) => {
    const {name, description, quantity} = req.body;
    const id = req.params.id;
    db.run(`UPDATE equipment SET name = ?, description = ?, quantity = ? WHERE id = ?`, [name, description, quantity, id], function(err) {
      if (err) {
        return console.log(err.message);
      }
      console.log(`Row(s) updated: ${this.changes}`);
    });
    res.status(200).send(`Equipment updated with ID: ${id}`);
  });
  
  // DELETE method route
  app.delete("/equipment/:id", (req, res) => {
    const id = req.params.id;
    db.run(`DELETE FROM equipment WHERE id = ?`, id, function(err) {
      if (err) {
        return console.log(err.message);
      }
      console.log(`Row(s) deleted ${this.changes}`);
    });
    res.status(200).send(`Equipment deleted with ID: ${id}`);
  });
  

app.listen(PORT, () => {
    console.log(`Server listening on ${PORT}`);
});


process.on("SIGINT", () => {
    db.close((err) => {
      if (err) {
        return console.error(err.message);
      }
      console.log('Closed the database connection.');
      process.exit(0);
    });
  });