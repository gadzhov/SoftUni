import React from 'react'
let List = React.createClass({
    render: function () {
        let items = [];
        for (let i in this.props.items)
            items.push(<li key={i}>{this.props.items[i]}</li>);
        return (
            <ul>{items}</ul>
        )
    }
});
export default List;