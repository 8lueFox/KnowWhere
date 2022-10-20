import { AccountCircle, Directions, Search } from "@mui/icons-material";
import { Autocomplete, Card, Divider, Icon, IconButton, InputBase, Paper, TextField, Typography } from "@mui/material";
import { styled } from "@mui/system";

const MyTextField = styled('MuiOutlinedInput')({
   color: 'red',
   backgroundColor: 'aliceblue',
   padding: 8,
   borderRadius: 4 
});

const fromOptions = [
    {label: 'Biała Podlaska', id: 1},
    {label: 'Omagh', id:2}
]

const SearchPanel = () => {
    return(
    <span id='SearchPanel'>
        <Paper 
            component="form"
            sx={{ p: '2px 4px', display: 'flex', alignItems: 'center', width: 400}}>
            <InputBase
                sx={{ml: 1, flex: 1}}
                placeholder="Search place"
                inputProps={{ 'aria-label': 'search place'}}
                />
            <IconButton type='button' sx={{p:'10px'}} aria-label='search'>
                <Search />
            </IconButton>
            <Divider sx={{height: 28, m: 0.5}} orientation='vertical'/>
            <IconButton color="primary" sx={{p:'10px'}} aria-label='directions'>
                <Directions />
            </IconButton>
        </Paper>
        <Paper
            sx={{p: '2px 4px', display: 'flex', alignItems: 'center', width: 400, flexDirection: 'column', borderRadius: 0}}>  
            <Card className="searchResult" sx={{display: 'flex', flexDirection: 'row'}}>
                <Icon sx={{p:'8px'}} aria-label='search'>
                    <Search sx={{height: '0.9em'}}/>
                </Icon>
                <Typography 
                    className="cityName"
                    sx={{p: '12px', pr: 0, fontFamily: 'Poppins, sans-serif',
                    fontWeight: 500, fontSize: 14}} >
                    Biała Podlaska
                </Typography>
                <Typography
                    className="countryName"
                    sx={{p: '14.5px', pl:1, fontFamily: 'Poppins, sans-serif',
                    fontWeight: 500, fontSize: 12}} >
                    Poland
                </Typography>
            </Card>
        </Paper>
    </span>)
}

export default SearchPanel;