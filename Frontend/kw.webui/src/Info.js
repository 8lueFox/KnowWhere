import { Card, Typography } from "@mui/material";
import { Container } from "@mui/system";
import './Info.css';

const Info = () => {
    return (
        <span>
        <Container maxWidth='md'>
            <Card style={{marginTop: '1em'}} maxWidth='sm'>
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
        <Container maxWidth='xl' style={{marginTop: '2em'}}>
            <Card>
                Actually online drivers: 10000
                Actually reported accidents: 5
            </Card>
        </Container>
        </span>
    );
}

export default Info;