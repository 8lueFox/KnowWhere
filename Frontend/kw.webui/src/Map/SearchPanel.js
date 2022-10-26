import React, { useState} from 'react';
import { useDispatch, useSelector } from 'react-redux'
import { Cancel, Directions, Search } from "@mui/icons-material";
import { Card, Divider, Icon, IconButton, InputBase, Paper, TextField, Tooltip, Typography } from "@mui/material";
import { setGlobalPointFrom, clearSuggestions, fetchSuggestions, selectInputSuggestions } from './MapSlice';

const SearchPanel = () => {
    const inputSuggestions = useSelector(selectInputSuggestions);
    const dispatch = useDispatch();
    
    const [pointFrom, setPointFrom] = useState('')
    const [pointTo, setPointTo] = useState('')
    const [pointFromObject, setPointFromObject] = useState('')
    const [pointToObject, setPointToObject] = useState('')
    const [isSearchDestinationOn, setIsSearchDestinationOn] = useState(false)

    const setPoint = (id) => {
        if(isSearchDestinationOn){
            setPointToObject(inputSuggestions[id])
            setPointTo(inputSuggestions[id].name + ', ' + inputSuggestions[id].country)
        }else{
            setPointFromObject(inputSuggestions[id])
            setPointFrom(inputSuggestions[id].name + ', ' + inputSuggestions[id].country)
            dispatch(setGlobalPointFrom(inputSuggestions[id]))
        }
        dispatch(clearSuggestions())
    }

    const setPointFromAndSearch = (input) => {
        setPointFrom(input)
        if(input.length > 3)
        dispatch(fetchSuggestions(pointFrom))
    }

    return(
    <span id='SearchPanel'>
        <Paper
            sx={{ p: '2px 4px', display: 'flex', alignItems: 'center', width: 400}}>
            <InputBase
                sx={{ml: 1, flex: 1}}
                placeholder="Search place"
                inputProps={{ 'aria-label': 'search place'}}
                value={pointFrom}
                onChange={(event) => setPointFromAndSearch(event.target.value)}
                onSubmit={e => { console.log('submit') }}
                />
            <IconButton type='button' sx={{p:'10px'}} aria-label='search' onClick={() => dispatch(fetchSuggestions(pointFrom))}>
                <Search />
            </IconButton>
            <Divider sx={{height: 28, m: 0.5}} orientation='vertical'/>
            <Tooltip placement='right' title={isSearchDestinationOn ? 'Cancel looking for route' : 'Get route'}>
                <IconButton color="primary" sx={{p:'10px'}} aria-label='directions' onClick={() => setIsSearchDestinationOn(!isSearchDestinationOn)}>
                    {isSearchDestinationOn ? <Cancel /> : <Directions />}   
                </IconButton>
            </Tooltip>
        </Paper>
        {isSearchDestinationOn &&
        <Paper 
            component="form"
            sx={{ p: '2px 4px', display: 'flex', alignItems: 'center', width: 400}}>
            <InputBase
                sx={{ml: 1, flex: 1}}
                placeholder="Search for a destination"
                inputProps={{ 'aria-label': 'search for a destination'}}
                value={pointTo}
                onChange={(event) => setPointTo(event.target.value)}
                />
            <IconButton type='button' sx={{p:'10px'}} aria-label='search' onClick={() => dispatch(fetchSuggestions(pointTo))}>
                <Search />
            </IconButton>
        </Paper>}
        {inputSuggestions.length > 0 &&
        <Paper
            sx={{p: '2px 4px', display: 'flex', alignItems: 'center', width: 400, flexDirection: 'column', borderRadius: 0}}>  
            {inputSuggestions.map((point, i)=>{
                return <Card className="searchResult" sx={{display: 'flex', flexDirection: 'row'}} id={i} onClick={() => setPoint(i)}>
                <Icon sx={{p:'8px'}} aria-label='search'>
                    <Search sx={{height: '0.9em'}}/>
                </Icon>
                <Typography 
                    className="cityName"
                    sx={{p: '12px', pr: 0, fontFamily: 'Poppins, sans-serif',
                    fontWeight: 500, fontSize: 14}} >
                    {point.street == null ? point.name : (point.housenumber + " " + point.street)}
                </Typography>
                <Typography
                    className="countryName"
                    sx={{p: '14.5px', pl:1, fontFamily: 'Poppins, sans-serif',
                    fontWeight: 500, fontSize: 12}} >
                    {point.street == null ? point.country : point.city}
                </Typography>
            </Card>
            })}
        </Paper>}
    </span>)
}

export default SearchPanel;