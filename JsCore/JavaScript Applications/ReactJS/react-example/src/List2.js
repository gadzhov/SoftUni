import React from 'react';

let List = React.createClass({
    render: function () {
        let items = this.props.items.map(function (item, i) {
            return <li key={i}>{item}</li>;
        });
        return (
            <ul>{items}</ul>
        )
    }
});
export default List