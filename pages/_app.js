import '../styles/globals.css'
import '../styles/fsdocs-default.css'
import Script from 'next/script'

function MyApp({ Component, pageProps }) {
  return <><Component {...pageProps} /><Script src="fsdocs-tips.js"></Script></>
}

export default MyApp
