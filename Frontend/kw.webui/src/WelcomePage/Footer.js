import { CarCrash } from "@mui/icons-material";
import { Box, Link, Paper, Typography } from "@mui/material";
import { Container } from "@mui/system";

const Footer = () => {
    return (
        <Paper sx={{marginTop: 'calc(10%+60px)', bottom:0, backgroundColor: 'rgb(47, 47, 47)'}} component='footer' square variant="outlined">
            <Container maxWidth='lg'>
                <Box
                    sx={{
                        flexGrow: 1,
                        justifyContent: 'center', 
                        display: 'flex',
                        my: 1
                    }}>
                    <Link href='/'>
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
                    </Link>
                </Box>
                <Box
                    sx={{
                        flexGrow: 1,
                        justifyContent: 'center',
                        display: 'flex',
                        mb: 2
                    }}
                >
                    <Typography variant="caption" color="initial">
                        Copyright ©2023. KnowWhere Limited
                    </Typography>
                </Box>
            </Container>
        </Paper>
    );
}

export default Footer;