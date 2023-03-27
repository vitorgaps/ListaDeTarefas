import React, { useEffect, useState } from 'react';
//import logo from './logo.svg';
import './App.css';
import { Box, Fab, Grid, Typography } from '@mui/material';
import { TaskCard } from './components/TaskCard/TaskCard';

function App() {
    const [tasksData, setTasksData] = useState([{
        "id": 1,
        "taskName": "Tarefa",
        "description": "Description",
        "startDate": new Date("2023-02-27T01:37:24.054Z"),
        "endDate": new Date("2023-03-27T01:37:24.054Z"),
        "finished": false
    },
    {
        "id": 2,
        "taskName": "Tarefa",
        "description": "Description",
        "startDate": new Date("2023-01-27T01:37:24.054Z"),
        "endDate": new Date("2023-02-27T01:37:24.054Z"),
        "finished": true
    },
    {
        "id": 3,
        "taskName": "Tarefa-Error-2",
        "description": "Description",
        "startDate": new Date("2023-02-27T01:37:24.054Z"),
        "endDate": new Date("2023-03-27T01:37:24.054Z"),
        "finished": true
    }]
    );
    return (
        <Grid container
            spacing={2}            
            style={{ padding: "4rem" }}>
            <Fab style={{ position: "fixed", bottom: "5%", right: "5%" }} color="secondary" variant="extended" sx={{ mr: 1 }}>
                Create
            </Fab>
            <Grid item xs={12}>
                    <Typography align="center" variant="h4" gutterBottom>
                        Task Management
                    </Typography>
            </Grid>

            <Grid container xs={12} spacing={1}>
                <Typography variant="h6" component='div'>Tasks remaining <Box fontWeight="bold" display='inline'>({tasksData.length})</Box></Typography>           

                {tasksData?.map(({ id, taskName, description, startDate, endDate, finished }) => {
                    return (
                        <TaskCard name={taskName} description={description} startDate={startDate} endDate={endDate} finished={finished}></TaskCard>
                    );
                })}
                
            </Grid>
        </Grid>
  );
}

export default App;
