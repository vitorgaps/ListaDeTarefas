import React, { Component } from 'react';
import { Box, Checkbox, Grid, Typography, Button, CardContent, CardActions, Card } from '@mui/material';

interface TaskCardProps {
    name: string;
    description: string;
    startDate: Date;
    endDate: Date;
    finished: boolean
}

export const TaskCard = ({ name, description, startDate, endDate, finished }: TaskCardProps) =>
    <Grid item xs={12} >
        <Card sx={{ display: "flex", flexDirection: "row" }}>
            <Checkbox checked={finished} disableRipple />
            <Grid >
                <CardContent>
                    <Typography gutterBottom variant="h5" component="div">
                        {name}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        {description}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Creation Date: {startDate.toLocaleString()}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        End Date: {endDate.toLocaleString()}
                    </Typography>
                </CardContent>
                <CardActions>
                    <Button size="small">Edit</Button>
                    <Button color="error" size="small">Delete</Button>
                </CardActions>
            </Grid >
        </Card>
    </Grid>