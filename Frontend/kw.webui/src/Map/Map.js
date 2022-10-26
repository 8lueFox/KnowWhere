import { useState } from "react";
import { MapContainer, Marker, Polyline, Popup, TileLayer, useMapEvent, ZoomControl } from "react-leaflet";
import { useSelector } from "react-redux";
import { selectPointFrom } from "./MapSlice";

const coords = [
[-7.298677,54.596393],[-7.299178,54.59626],[-7.299258,54.596209],[-7.299251,54.59615],[-7.298718,54.595516],[-7.299482,54.595256],[-7.300373,54.594983],[-7.300931,54.595949],[-7.301054,54.596101],[-7.302269,54.597029],[-7.302338,54.597134],[-7.302338,54.597224],[-7.302202,54.597342],[-7.302049,54.597399],[-7.301768,54.597439],[-7.301554,54.596952],[-7.303579,54.59657],[-7.304158,54.596493],[-7.304564,54.596468],[-7.305024,54.596464],[-7.305395,54.596481],[-7.305842,54.596522],[-7.306684,54.596654],[-7.307369,54.596818],[-7.307762,54.596938],[-7.308591,54.597245],[-7.308967,54.59741],[-7.309358,54.597628],[-7.309702,54.597881],[-7.309838,54.59802],[-7.310014,54.598151],[-7.310269,54.598537],[-7.310369,54.598756],[-7.31082,54.599174],[-7.311298,54.599539],[-7.311668,54.599771],[-7.312201,54.60004],[-7.314848,54.60123],[-7.315301,54.601458],[-7.316093,54.601901],[-7.317662,54.602931],[-7.318501,54.603566],[-7.31966,54.604588],[-7.32106,54.605872],[-7.322845,54.607942],[-7.323497,54.608662],[-7.324105,54.609584],[-7.32427,54.609969],[-7.324478,54.610714],[-7.324606,54.611081],[-7.324661,54.611206],[-7.32474,54.611308],[-7.324802,54.611399],[-7.324795,54.611457],[-7.324629,54.611665],[-7.324529,54.611947],[-7.324666,54.612339],[-7.324927,54.612812],[-7.324989,54.612911],[-7.325206,54.613155],[-7.325865,54.613698],[-7.32768,54.615079],[-7.330353,54.617066],[-7.33097,54.617658],[-7.332652,54.619396],[-7.333133,54.619918],[-7.336481,54.624211],[-7.337318,54.625193],[-7.337676,54.625726],[-7.337938,54.626282],[-7.339172,54.629184],[-7.340877,54.633278],[-7.343089,54.638471],[-7.344199,54.641015],[-7.3443,54.641308],[-7.344367,54.641626],[-7.344339,54.642115],[-7.34425,54.64242],[-7.344175,54.642583],[-7.343856,54.643017],[-7.343478,54.643414],[-7.342795,54.644063],[-7.341917,54.644857],[-7.341422,54.645359],[-7.3411,54.645774],[-7.341028,54.645974],[-7.34092,54.646146],[-7.340107,54.647958],[-7.339353,54.649223],[-7.339058,54.649823],[-7.338589,54.652452],[-7.338272,54.653685],[-7.337736,54.65493],[-7.337507,54.655372],[-7.336579,54.65646],[-7.336444,54.656778],[-7.336421,54.657118],[-7.336459,54.657399],[-7.336691,54.657867],[-7.337011,54.658338],[-7.33733,54.65897],[-7.339121,54.663902],[-7.339669,54.66523],[-7.339915,54.66566],[-7.340212,54.666058],[-7.340595,54.666444],[-7.341063,54.666792],[-7.341858,54.667334],[-7.345477,54.669079],[-7.347555,54.670059],[-7.349379,54.670981],[-7.349882,54.671301],[-7.350351,54.671655],[-7.350821,54.672133],[-7.351085,54.672518],[-7.351258,54.672875],[-7.351414,54.673356],[-7.351724,54.675431],[-7.352254,54.677196],[-7.352457,54.677726],[-7.352785,54.67899],[-7.352943,54.680097],[-7.352828,54.682368],[-7.352641,54.684713],[-7.352395,54.686816],[-7.352181,54.688181],[-7.352166,54.689271],[-7.35231,54.689994],[-7.352435,54.690416],[-7.353172,54.69179],[-7.353474,54.692541],[-7.353887,54.694142],[-7.353909,54.694538],[-7.35385,54.695074],[-7.353252,54.696887],[-7.353189,54.697271],[-7.353211,54.697683],[-7.353333,54.698036],[-7.353604,54.698551],[-7.353982,54.699188],[-7.354342,54.699884],[-7.354522,54.700436],[-7.354645,54.701071],[-7.354711,54.702153],[-7.354834,54.702738],[-7.355033,54.703258],[-7.355329,54.703771],[-7.355676,54.704231],[-7.356159,54.7048],[-7.357398,54.706413],[-7.35825,54.708001],[-7.359622,54.710229],[-7.360163,54.71105],[-7.360591,54.711544],[-7.361118,54.712043],[-7.362487,54.713134],[-7.363076,54.713636],[-7.363493,54.714063],[-7.363788,54.714427],[-7.364096,54.714941],[-7.364462,54.715773],[-7.365239,54.717783],[-7.365514,54.718243],[-7.365874,54.718607],[-7.36626,54.718941],[-7.367007,54.719405],[-7.367691,54.719779],[-7.369157,54.720477],[-7.370781,54.721127],[-7.371763,54.721437],[-7.372732,54.721763],[-7.374676,54.722331],[-7.374463,54.722562],[-7.373238,54.722901],[-7.372988,54.722951],[-7.372689,54.723062],[-7.372068,54.72349],[-7.370256,54.724183],[-7.369888,54.724369],[-7.36891,54.725026],[-7.368269,54.725306],[-7.365792,54.725793],[-7.365637,54.725807],[-7.364927,54.725818],[-7.364947,54.725874],[-7.364994,54.72592],[-7.365125,54.725977],[-7.366843,54.726919],[-7.366915,54.726991],[-7.367051,54.727531],[-7.367001,54.727784],[-7.367037,54.727925],[-7.367105,54.728053],[-7.367208,54.728165],[-7.367488,54.728319],[-7.367595,54.728414],[-7.367692,54.728528],[-7.367896,54.728887],[-7.368248,54.729304],[-7.368419,54.729428],[-7.369336,54.730398],[-7.369399,54.730524],[-7.369449,54.730727],[-7.369458,54.730877],[-7.369422,54.731091],[-7.369368,54.731264],[-7.369078,54.731643],[-7.369017,54.731804],[-7.368999,54.731934],[-7.369053,54.732116],[-7.369003,54.732321],[-7.368817,54.732708],[-7.368254,54.733685],[-7.368147,54.733821],[-7.367062,54.734609],[-7.366773,54.734785],[-7.366557,54.734862],[-7.365894,54.735045],[-7.365499,54.735175],[-7.365124,54.735357],[-7.365012,54.735431],[-7.364827,54.735625],[-7.364672,54.735869],[-7.363771,54.737109],[-7.36334,54.737635],[-7.362651,54.738322],[-7.362125,54.738891],[-7.361494,54.739521],[-7.361225,54.739754],[-7.360899,54.739922],[-7.359822,54.740409],[-7.358377,54.741009],[-7.357988,54.741198],[-7.35775,54.741373],[-7.35764,54.741523],[-7.357571,54.742248],[-7.357391,54.742763],[-7.357373,54.742911],[-7.357518,54.743403],[-7.357125,54.743594],[-7.356775,54.7437],[-7.356315,54.743815],[-7.355983,54.743943],[-7.355711,54.744067],[-7.354772,54.744561],[-7.354296,54.744789],[-7.352269,54.745904],[-7.350967,54.746681],[-7.350703,54.746879],[-7.350602,54.746997],[-7.350439,54.74725],[-7.349748,54.748436],[-7.349007,54.749791],[-7.348725,54.750565],[-7.34873,54.750674],[-7.348896,54.751006],[-7.348914,54.751137],[-7.348881,54.751268],[-7.348793,54.751406],[-7.348697,54.7515],[-7.348526,54.751599],[-7.348409,54.751723],[-7.348068,54.752217],[-7.347925,54.752354],[-7.347592,54.752604],[-7.347434,54.752747],[-7.347224,54.752998],[-7.346999,54.753163],[-7.346889,54.753271],[-7.346709,54.753232],[-7.345821,54.75419],[-7.344877,54.754974],[-7.344049,54.755873],[-7.342717,54.757605],[-7.341669,54.758751],[-7.340596,54.759631],[-7.339981,54.760083],[-7.339438,54.760695],[-7.338727,54.761576],[-7.337938,54.762232],[-7.337187,54.762949],[-7.336153,54.763773],[-7.33581,54.7639],[-7.334807,54.764165],[-7.334141,54.764359],[-7.333941,54.764542],[-7.333934,54.764747],[-7.333986,54.764964],[-7.334128,54.765318],[-7.334251,54.765755],[-7.334374,54.767228],[-7.334665,54.768504],[-7.334665,54.768814],[-7.334497,54.769172],[-7.333857,54.770045],[-7.333314,54.770728],[-7.331399,54.772228],[-7.330934,54.772649],[-7.330752,54.772892],[-7.330507,54.773421],[-7.330306,54.774343],[-7.330028,54.775163],[-7.32955,54.776286],[-7.329323,54.776935],[-7.329258,54.777189],[-7.329064,54.777443],[-7.328275,54.777864],[-7.327984,54.778163],[-7.327862,54.778442],[-7.327739,54.778841],[-7.327751,54.779645],[-7.327357,54.780885],[-7.327149,54.78168],[-7.328122,54.782056],[-7.328572,54.782188],[-7.329903,54.782486],[-7.331424,54.7828],[-7.332889,54.783046],[-7.333405,54.783108],[-7.334088,54.78316],[-7.335561,54.783357],[-7.337064,54.783654],[-7.339946,54.784165],[-7.340571,54.784309],[-7.342116,54.784813],[-7.342411,54.784937],[-7.342681,54.785077],[-7.343131,54.785424],[-7.34372,54.785999],[-7.344074,54.786402],[-7.344659,54.786795],[-7.345074,54.786929],[-7.345547,54.787018],[-7.346341,54.787124],[-7.347173,54.787196],[-7.348014,54.78726],[-7.349317,54.787314],[-7.350668,54.78739],[-7.351314,54.787494],[-7.352346,54.787764],[-7.353953,54.788235],[-7.354389,54.788432],[-7.355196,54.78884],[-7.356224,54.789423],[-7.356544,54.789631],[-7.356635,54.789713],[-7.356835,54.789959],[-7.357259,54.790664],[-7.357455,54.790931],[-7.357831,54.791278],[-7.358023,54.791423],[-7.358169,54.791498],[-7.35831,54.791533],[-7.358473,54.791539],[-7.358744,54.791514],[-7.359677,54.791341],[-7.360395,54.791156],[-7.360635,54.791123],[-7.360856,54.791135],[-7.361057,54.791195],[-7.361399,54.791363],[-7.361839,54.791544],[-7.361791,54.791641],[-7.361769,54.791763],[-7.361739,54.792506],[-7.361481,54.795426],[-7.361546,54.796935],[-7.361696,54.798221],[-7.361202,54.802414],[-7.361031,54.803367],[-7.360225,54.80522],[-7.359979,54.805704],[-7.359938,54.806468],[-7.359915,54.806563],[-7.359944,54.806676],[-7.359846,54.807054],[-7.359366,54.807602],[-7.359185,54.807743],[-7.359001,54.807861],[-7.358626,54.80806],[-7.358499,54.808194],[-7.358487,54.808355],[-7.358572,54.809216],[-7.358596,54.809933],[-7.358655,54.810658],[-7.359002,54.811761],[-7.359087,54.811925],[-7.35929,54.812169],[-7.35951,54.812398],[-7.360252,54.813057],[-7.36108,54.813882],[-7.362792,54.815238],[-7.362952,54.815388],[-7.363073,54.815538],[-7.363178,54.815762],[-7.363263,54.816125],[-7.363321,54.81739],[-7.363292,54.817588],[-7.363188,54.817771],[-7.363057,54.817892],[-7.362618,54.818225],[-7.362482,54.818412],[-7.362451,54.818637],[-7.36258,54.82012],[-7.362645,54.820412],[-7.362764,54.820657],[-7.362942,54.820928],[-7.363227,54.821251],[-7.363909,54.821898],[-7.364502,54.822513],[-7.365128,54.823112],[-7.36541,54.823493],[-7.365548,54.823835],[-7.365584,54.824092],[-7.365578,54.824387],[-7.365541,54.824636],[-7.365223,54.825926],[-7.365173,54.826248],[-7.365167,54.826492],[-7.365194,54.826688],[-7.365282,54.826935],[-7.366045,54.827969],[-7.366637,54.828685],[-7.366706,54.828901],[-7.366723,54.829459],[-7.366803,54.829681],[-7.367163,54.830243],[-7.367788,54.831059],[-7.368288,54.831648],[-7.368491,54.831932],[-7.368497,54.832015],[-7.367751,54.831986],[-7.367338,54.831988],[-7.366821,54.83202],[-7.366269,54.832089],[-7.366052,54.832101],[-7.364621,54.832089],[-7.364372,54.832098],[-7.364185,54.832136],[-7.363989,54.832233],[-7.363699,54.832438],[-7.363186,54.832754],[-7.363329,54.832961],[-7.36362,54.833271],[-7.363749,54.833359],[-7.36388,54.833396],[-7.367422,54.833894],[-7.367916,54.833977],[-7.369334,54.834483],[-7.370907,54.835098],[-7.37129,54.835287],[-7.371982,54.8358],[-7.373977,54.837561],[-7.375335,54.838509],[-7.375528,54.83867],[-7.375764,54.838982],[-7.37603,54.839093],[-7.376808,54.839238],[-7.377382,54.839417],[-7.3777,54.839486],[-7.378237,54.839565],[-7.378502,54.839632],[-7.378561,54.83966],[-7.378744,54.840066],[-7.378985,54.840376],[-7.379535,54.840925],[-7.379683,54.840987],[-7.380017,54.841083],[-7.38011,54.841125],[-7.380847,54.841626],[-7.381314,54.841914],[-7.381405,54.842028],[-7.381455,54.84261],[-7.381416,54.84293],[-7.381405,54.843619],[-7.381367,54.843886],[-7.381148,54.844573],[-7.381162,54.844631],[-7.381471,54.844866],[-7.381949,54.845114],[-7.382528,54.845265],[-7.384817,54.845719],[-7.384935,54.845757],[-7.385019,54.845808],[-7.385767,54.845794],[-7.386692,54.845823],[-7.387201,54.845814],[-7.388635,54.845828],[-7.38987,54.845656],[-7.390151,54.845666],[-7.390305,54.845687],[-7.390881,54.845836],[-7.391442,54.845918],[-7.391678,54.845972],[-7.392587,54.84637],[-7.393347,54.846649],[-7.393558,54.846751],[-7.39368,54.846852],[-7.393886,54.84715],[-7.394069,54.847314],[-7.394266,54.847445],[-7.394585,54.847603],[-7.394881,54.84784],[-7.395125,54.847951],[-7.396138,54.848283],[-7.396302,54.848351],[-7.396387,54.84841],[-7.396682,54.848727],[-7.396808,54.848786],[-7.397202,54.848869],[-7.39754,54.848959],[-7.398797,54.849364],[-7.399073,54.849477],[-7.399663,54.849823],[-7.400402,54.850128],[-7.400662,54.850187],[-7.401175,54.850266],[-7.401342,54.850321],[-7.401437,54.850386],[-7.401712,54.850707],[-7.401826,54.850761],[-7.402131,54.850864],[-7.402613,54.850956],[-7.403382,54.851219],[-7.403533,54.851235],[-7.403542,54.85132],[-7.403621,54.851461],[-7.40361,54.851808],[-7.404066,54.852619],[-7.404603,54.853236],[-7.40486,54.853501],[-7.405445,54.853971],[-7.405799,54.854282],[-7.405917,54.854446],[-7.405912,54.854654],[-7.405815,54.854875],[-7.405633,54.855444],[-7.405672,54.8561],[-7.405601,54.856117],[-7.404028,54.85626],[-7.40368,54.856337],[-7.403305,54.856491],[-7.403319,54.857013],[-7.40341,54.85791],[-7.403538,54.85863],[-7.403619,54.859731],[-7.403702,54.859839],[-7.403954,54.860004],[-7.405393,54.860497],[-7.405639,54.860613],[-7.405899,54.860823],[-7.406165,54.861361],[-7.406405,54.862008],[-7.407111,54.862579],[-7.407568,54.862852],[-7.408058,54.863195],[-7.408259,54.863395],[-7.408389,54.863447],[-7.408605,54.86347],[-7.408822,54.863436],[-7.409191,54.863433],[-7.410321,54.863747],[-7.410763,54.86384],[-7.411261,54.863907],[-7.411676,54.863925],[-7.413357,54.863936],[-7.41439,54.863926],[-7.414943,54.863894],[-7.415589,54.863769],[-7.416523,54.863561],[-7.416777,54.86359],[-7.420365,54.86458],[-7.420826,54.864666],[-7.422296,54.864703],[-7.422545,54.864733],[-7.423107,54.864882],[-7.423378,54.864929],[-7.423463,54.864927],[-7.423746,54.871435],[-7.42374,54.871887],[-7.423683,54.872208],[-7.423541,54.872669],[-7.42306,54.873569],[-7.422386,54.874713],[-7.422169,54.875202],[-7.421803,54.876289],[-7.421598,54.877135],[-7.421377,54.877821],[-7.421191,54.878257],[-7.420568,54.879443],[-7.420071,54.880309],[-7.419477,54.881049],[-7.418989,54.881733],[-7.418444,54.882544],[-7.418295,54.882817],[-7.418171,54.883107],[-7.41806,54.883488],[-7.417948,54.884007],[-7.417903,54.884389],[-7.417947,54.886804],[-7.418214,54.888026],[-7.418527,54.889275],[-7.418581,54.889438],[-7.419063,54.890514],[-7.41997,54.893004],[-7.420123,54.893522],[-7.420376,54.89486],[-7.420673,54.89573],[-7.421052,54.896596],[-7.421446,54.897342],[-7.421714,54.897906],[-7.42182,54.898306],[-7.421832,54.898583],[-7.421804,54.898801],[-7.421676,54.899305],[-7.421176,54.901135],[-7.421048,54.901731],[-7.420962,54.90234],[-7.420955,54.903417],[-7.421275,54.906225],[-7.421256,54.907114],[-7.421178,54.908153],[-7.421003,54.909171],[-7.420277,54.912712],[-7.419869,54.914877],[-7.419185,54.918212],[-7.419075,54.918658],[-7.418992,54.918799],[-7.41584,54.921491],[-7.413923,54.922864],[-7.413443,54.923182],[-7.411836,54.923993],[-7.411305,54.92422],[-7.410188,54.924758],[-7.409549,54.925115],[-7.408868,54.925584],[-7.408153,54.926125],[-7.407473,54.926575],[-7.405789,54.927501],[-7.404653,54.928209],[-7.4029,54.929511],[-7.399228,54.93232],[-7.398065,54.933124],[-7.397109,54.933711],[-7.396267,54.934184],[-7.388006,54.938561],[-7.385789,54.939788],[-7.382669,54.941483],[-7.381669,54.942006],[-7.380853,54.942399],[-7.380427,54.942633],[-7.376848,54.945422],[-7.376398,54.945801],[-7.374865,54.947304],[-7.373503,54.948733],[-7.372866,54.949304],[-7.370702,54.950978],[-7.368089,54.953094],[-7.36757,54.953468],[-7.366393,54.954269],[-7.362779,54.956627],[-7.362161,54.957001],[-7.359873,54.958481],[-7.358514,54.959302],[-7.357788,54.959665],[-7.357678,54.959734],[-7.35753,54.959885],[-7.357009,54.960557],[-7.356162,54.962237],[-7.355443,54.963941],[-7.354924,54.965684],[-7.354324,54.968394],[-7.353767,54.969536],[-7.351968,54.97275],[-7.350648,54.974769],[-7.34952,54.976452],[-7.349331,54.976776],[-7.34874,54.977374],[-7.348319,54.977735],[-7.347557,54.978303],[-7.346847,54.978794],[-7.34624,54.979158],[-7.345463,54.979554],[-7.344413,54.980004],[-7.343155,54.980457],[-7.34137,54.980991],[-7.338355,54.981829],[-7.336087,54.982507],[-7.332947,54.983425],[-7.33162,54.983757],[-7.330696,54.983938],[-7.330214,54.984028],[-7.329325,54.984139],[-7.328518,54.984287],[-7.327318,54.984604],[-7.326583,54.984856],[-7.325713,54.985223],[-7.32478,54.985647]
]

const Map = () => {
    const [mapRef, setMapRef] = useState(null)
    const pointFrom = useSelector(selectPointFrom);

    if(pointFrom != null)
     mapRef.flyTo([pointFrom.point.lat, pointFrom.point.lng], pointFrom.city != null ? 18 : 13)

    return(
        <span id='Map'>
            {console.log(<MapContainer />)}
            <MapContainer center={[coords[0][1], coords[0][0]]} 
                zoom={13} 
                scrollWheelZoom={true} 
                zoomControl={false}
                ref={setMapRef}>
                <TileLayer
                    attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                    url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                />
                <ZoomControl position="topright" />
                {
                    coords.map((item, index) => {
                        if(index == coords.length - 1)
                            return
                        return <Polyline id={index} positions={[[item[1],item[0]], [coords[index+1][1],coords[index+1][0]]]} color={'red'} />
                    })
                }

            </MapContainer>
        </span>
    )
}


export default Map;