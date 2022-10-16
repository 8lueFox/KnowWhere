import { Button, Card, Typography } from "@mui/material";
import { Container } from "@mui/system";
import './Info.css';

const Info = () => {
    return (
        <span style={{paddingBottom: '2em'}}>
        <Container maxWidth='md'>
            <Card style={{marginTop: '5em', marginBottom: '1em'}} maxWidth='sm'>
                <Typography
                    variant="h5"
                    noWrap
                    sx={{
                        mr: 2,
                        fontFamily: 'Poppins, sans-serif',
                        fontWeight: 700,
                        paddingTop: '1em',
                        paddingBottom: '1em'
                    }}
                    >
                    KnowWhere - driver's friend
                </Typography>
                <Typography
                    variant="h7"
                    fontFamily={'Poppins, sans-serif'}
                    paddingBottom='1em'
                    >
                    It's a road alert system, created by drivers for drivers.
                    A true friend of motorists, who informs, inter alia, about dangers, accidents, speed cameras and police checks.
                </Typography>
                <Typography
                    marginTop={'1em'}
                    paddingBottom={'1em'}>
                    Drive safely and without fines.
                </Typography>
            </Card>
        </Container>
        <Container maxWidth="xl" id='statsInfo'>
            <Card id='statsInfoHeader'>
                <Typography
                    variant="h4"
                    color={'rgb(226, 226, 226)'}
                    paddingTop={'1em'}
                    fontWeight={'700'}
                    >
                    Actually:
                </Typography>
            </Card>
            <Card id='statsInfoActualls'>
                <span className="stat">
                    <h1>Online drivers:</h1>
                    <p>5000</p>
                </span>
                <span className="stat">
                    <h1>Reported accidents:</h1>
                    <p>9923</p>
                </span>
                <span className="stat">
                    <h1>Reported police checks:</h1>
                    <p>1204</p>
                </span>
                <span className="stat">
                    <h1>Reported speed cameras:</h1>
                    <p>923232</p>
                </span>
            </Card>
            <Card id="statsInfoButton">
                <Button variant="contained" color="error">
                    Navigate now
                </Button>
            </Card>
        </Container>
        </span>
    );
}

export default Info;