import SearchPanel from "./SearchPanel";
import Map from './Map'
import './Map.css';

const MapLayout = () => {
    return(
        <span id='MapLayout'>
            <SearchPanel />
            <Map />
        </span>
    )
}

export default MapLayout;