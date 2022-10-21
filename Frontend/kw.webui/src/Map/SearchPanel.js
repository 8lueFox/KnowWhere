import React, { useState} from 'react';
import { useDispatch, useSelector } from 'react-redux'
import { AccountCircle, Cancel, Directions, Search } from "@mui/icons-material";
import { Autocomplete, Card, Divider, Icon, IconButton, InputBase, Paper, TextField, Tooltip, Typography } from "@mui/material";
import { clearSuggestions, fetchSuggestions, selectInputSuggestions } from './MapSlice';

const SearchPanel = () => {
    const inputSuggestions = useSelector(selectInputSuggestions);
    const dispatch = useDispatch();
    
    const [pointFrom, setPointFrom] = useState('')
    const [pointTo, setPointTo] = useState('')
    const [pointFromObject, setPointFromObject] = useState('')
    const [pointToObject, setPointToObject] = useState('')
    const [isSearchDestinationOn, setIsSearchDestinationOn] = useState(false)

    const setPoint = (id) => {
        console.log('setPoint ' + id)
        setPointFromObject(inputSuggestions[id])
        setPointFrom(inputSuggestions[id].city + ', ' + inputSuggestions[id].country)
        dispatch(clearSuggestions())
    }

    return(
    <span id='SearchPanel'>
        <Paper 
            component="form"
            sx={{ p: '2px 4px', display: 'flex', alignItems: 'center', width: 400}}>
            <InputBase
                sx={{ml: 1, flex: 1}}
                placeholder="Search place"
                inputProps={{ 'aria-label': 'search place'}}
                value={pointFrom}
                onChange={(event) => setPointFrom(event.target.value)}
                />
            <IconButton type='button' sx={{p:'10px'}} aria-label='search' onClick={() => dispatch(fetchSuggestions(''))}>
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
                />
            <IconButton type='button' sx={{p:'10px'}} aria-label='search' onClick={() => dispatch(fetchSuggestions(''))}>
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
                    {point.city}
                </Typography>
                <Typography
                    className="countryName"
                    sx={{p: '14.5px', pl:1, fontFamily: 'Poppins, sans-serif',
                    fontWeight: 500, fontSize: 12}} >
                    {point.country}
                </Typography>
            </Card>
            })}
        </Paper>}
    </span>)
}

export default SearchPanel;