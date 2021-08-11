import {useState, useEffect} from 'react';
import './App.css';

function App() {
  const obtDatosUsuario=async()=>{
    await fetch('http://localhost:41842/api/USUARIOs')
    .then(response => response.json())
    .then(response => console.log(response.data));
  }
  useEffect(()=>{
    obtDatosUsuario();
  },[]);
  
  return (
    <div className="App">
      <p>Corriendo servidor OK</p>
      
    </div>
  );
}

export default App;
