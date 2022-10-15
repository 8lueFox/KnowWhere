import { CarCrash } from '@mui/icons-material';
import { AppBar, Avatar, Box, IconButton, Toolbar, Tooltip, Typography } from '@mui/material';
import { Container } from '@mui/system';
import './Header.css';

const Header = () => {
    return (
        <AppBar position='static' style={{backgroundColor: '#2c2c2c'}}>
            <Container maxWidth='x1'>
                <Toolbar disableGutters>
                    <Typography
                        variant='h6'
                        noWrap
                        component='a'
                        href='/'
                        sx={{
                            mr: 2,
                            display: {xs: 'flex', md: 'flex'},
                            fontFamily: 'Rubik',
                            fontWeight: 700,
                            letterSpacing: '.2em',
                            color: 'rgb(226, 226, 226)',
                            textDecoration: 'none'
                        }}
                    >
                        <CarCrash style={{paddingTop: '5px', paddingRight: '5px'}} />
                        <span class='redText'>K</span>now<span class='redText'>W</span>here
                    </Typography>

                    <Box sx={{flexGrow: 0}} style={{position: 'absolute', right: '0px'}}>
                        <Tooltip title="Open settings">
                            <IconButton sx={{p:0}}>
                                <Avatar alt="8lueFox" src="./images/bluefox.jpg" />
                            </IconButton>
                        </Tooltip>
                    </Box>   
                </Toolbar>
            </Container>
        </AppBar>
    )
}

export default Header;