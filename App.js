import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import './style.css';
import 'bootstrap/dist/css/bootstrap.min.css';

export default function App() {
  const [tasks, setTasks] = useState([]);
  const [value, setValue] = useState('');

  const handleAdd = () => {
    const newTask = {
      id: new Date().getTime(),
      text: value,
      checked: false,
    };

    setTasks((prevState) => [...prevState, newTask]);
  };
  const handleDelete = (taskID) => {
    const newTasks = tasks.filter((task) => task.id !== taskID);
    setTasks(newTasks);
  };

  const onChangeInputHandler = (e) => setValue(e.target.value);

  return (
    <div>
      <h1>To Do List</h1>
      <input
        class="form-control"
        type="text"
        value={value}
        onChange={onChangeInputHandler}
      ></input>
      <button
        class="btn btn-primary"
        onClick={handleAdd}
        style={{ width: '100%' }}
      >
        Dodaj
      </button>

      {tasks.map((task) => {
        return (
          <div class="card task" style={{ width: '100%' }}>
            <div class="card-body">
              {task.text}
              <div className="actions">
                <input type="checkbox" class="form-check-input"></input>
                <button
                  class="btn btn-danger"
                  onClick={() => handleDelete(task.id)}
                >
                  X
                </button>
              </div>
            </div>
          </div>
        );
      })}
    </div>
  );
}
