import { MapContainer, Marker, Popup, TileLayer, useMapEvent } from "react-leaflet";

const Map = () => {
    return(
        <span id='Map'>
            <MapContainer center={[54.595545,-7.3]} zoom={13} scrollWheelZoom={true}>
                <TileLayer
                    attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                    url="https://cartodb-basemaps-{s}.global.ssl.fastly.net/light_all/{z}/{x}/{y}.png"
                />
                <MapHandler />
            </MapContainer>
        </span>
    )
}

const MapHandler = () => {
    const map = useMapEvent('click', () => {
        map.setCenter([50.5, 30.5])
    })
    return null
}

export default Map;